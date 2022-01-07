using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Base editor for all scriptable events. This is used as a default editor if no custom editor
    /// is defined.
    /// </summary>
    [CanEditMultipleObjects]
    public abstract class BaseScriptableEventEditor : UnityEditor.Editor
    {
        #region Fields

        // Labels.
        private GUIContent descriptionLabelContent;
        private GUIContent isSuppressExceptionsLabelContent;
        private GUIContent isDebugLabelContent;
        private GUIContent listenerLabelContent;

        // Target properties.
        private BaseScriptableEvent baseScriptableEvent;
        private MonoScript monoScript;

        // Cached properties.
        private SerializedProperty descriptionProperty;
        private SerializedProperty isSuppressExceptionsProperty;
        private SerializedProperty isDebugProperty;

        // Cached styles.
        private GUIStyle descriptionLockStyle;
        private GUIStyle descriptionHelpBoxStyle;
        private GUIStyle descriptionStyle;
        private GUIStyle listenerSubLabelStyle;

        private float descriptionWidth;
        private bool isLockDescription = true;
        private bool isSetupStyles = true;

        #endregion

        #region Unity Lifecycle

        internal virtual void OnEnable()
        {
            SetupLabelContent();
            SetupScriptableEvent();
            SetupMonoScript();
            SetupSerializedProperties();
        }

        public override void OnInspectorGUI()
        {
            if (isSetupStyles)
            {
                SetupStyles();
                isSetupStyles = false;
            }

            DrawMonoScript();

            EditorGUI.BeginChangeCheck();
            DrawDescription();

            EditorGUILayout.Space();
            DrawIsSuppressExceptions();
            DrawIsDebug();
            DrawAdditionalProperties();

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }

            EditorGUILayout.Space();
            DrawListeners();
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Can be used to draw properties right under other essential scriptable event properties.
        /// </summary>
        internal virtual void DrawAdditionalProperties()
        {
        }

        #endregion

        #region Private Setup Methods

        private void SetupLabelContent()
        {
            descriptionLabelContent = CreateLabelContent("description");
            isSuppressExceptionsLabelContent = CreateLabelContent("isSuppressExceptions");
            isDebugLabelContent = CreateLabelContent("isDebug");
            listenerLabelContent = new GUIContent(
                "Added Listeners",
                "Listeners added to this event"
            );
        }

        private void SetupScriptableEvent()
        {
            baseScriptableEvent = target as BaseScriptableEvent;
        }

        private void SetupMonoScript()
        {
            monoScript = MonoScript.FromScriptableObject(baseScriptableEvent);
        }

        private void SetupSerializedProperties()
        {
            descriptionProperty = serializedObject.FindProperty("description");
            isSuppressExceptionsProperty = serializedObject.FindProperty("isSuppressExceptions");
            isDebugProperty = serializedObject.FindProperty("isDebug");
        }

        private void SetupStyles()
        {
            SetupDescriptionLockStyle();
            SetupDescriptionHelpBoxStyle();
            SetupDescriptionStyle();
            SetupDescriptionWidth();
            SetupListenerSubLabelStyle();
        }

        private void SetupDescriptionLockStyle()
        {
            descriptionLockStyle = GUI.skin.GetStyle("IN LockButton");
        }

        private void SetupDescriptionHelpBoxStyle()
        {
            descriptionHelpBoxStyle = new GUIStyle(EditorStyles.helpBox)
            {
                fontSize = EditorStyles.textField.fontSize,
                richText = true
            };
        }

        private void SetupDescriptionStyle()
        {
            descriptionStyle = new GUIStyle(EditorStyles.textArea)
            {
                richText = true,
                wordWrap = true
            };
        }

        private void SetupDescriptionWidth()
        {
            var descriptionLabelSize = EditorStyles.label.CalcSize(descriptionLabelContent);
            descriptionWidth = descriptionLabelSize.x;
        }

        private void SetupListenerSubLabelStyle()
        {
            var labelSkin = GUI.skin.label;
            listenerSubLabelStyle = new GUIStyle(labelSkin)
            {
                fontSize = (int) (labelSkin.fontSize * 0.9f),
                wordWrap = true
            };
        }

        #endregion

        #region Private Draw Methods

        private void DrawMonoScript()
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", monoScript, target.GetType(), false);
            GUI.enabled = true;
        }

        private void DrawDescription()
        {
            EditorGUILayout.LabelField(descriptionLabelContent);
            DrawDescriptionLockButton();

            if (isLockDescription)
            {
                DrawDescriptionHelpBox();
            }
            else
            {
                DrawDescriptionTextArea();
            }
        }

        private void DrawDescriptionLockButton()
        {
            var position = GUILayoutUtility.GetLastRect();
            position.width = descriptionLockStyle.fixedWidth;
            position.x = position.xMin + descriptionWidth;

            isLockDescription = EditorGUI.Toggle(
                position,
                GUIContent.none,
                isLockDescription,
                descriptionLockStyle
            );
        }

        private void DrawDescriptionHelpBox()
        {
            var description = descriptionProperty.stringValue;
            if (string.IsNullOrWhiteSpace(description))
            {
                EditorGUILayout.LabelField(
                    "Click the <b>lock</b> icon to add a description to this event asset",
                    descriptionHelpBoxStyle
                );
                return;
            }

            EditorGUILayout.LabelField(description, descriptionHelpBoxStyle);
        }

        private void DrawDescriptionTextArea()
        {
            descriptionProperty.stringValue = EditorGUILayout.TextArea(
                descriptionProperty.stringValue,
                descriptionStyle
            );
        }

        private void DrawIsSuppressExceptions()
        {
            isSuppressExceptionsProperty.boolValue = EditorGUILayout.Toggle(
                isSuppressExceptionsLabelContent,
                isSuppressExceptionsProperty.boolValue
            );
        }

        private void DrawIsDebug()
        {
            isDebugProperty.boolValue = EditorGUILayout.Toggle(
                isDebugLabelContent,
                isDebugProperty.boolValue
            );
        }

        private void DrawListeners()
        {
            EditorGUILayout.LabelField(listenerLabelContent);

            if (baseScriptableEvent.Listeners.Count == 0)
            {
                EditorGUILayout.HelpBox(
                    "There are no listeners added to this event",
                    MessageType.Info
                );

                return;
            }

            GetListeners(out var objectListeners, out var otherListeners);

            EditorGUILayout.LabelField(
                $"Event contains {objectListeners.Count} UnityEngine.Object listeners and " +
                $"{otherListeners.Count} other listeners",
                listenerSubLabelStyle
            );

            DrawListenerFields(objectListeners);
            EditorGUILayout.Space();
            DrawListenerFields(otherListeners);
        }

        private static void DrawListenerFields(IEnumerable<Object> listenerObjects)
        {
            foreach (var listenerObject in listenerObjects)
            {
                EditorGUILayout.ObjectField(listenerObject, null, false);
            }
        }

        private static void DrawListenerFields(IEnumerable<string> listenerNames)
        {
            var height = GUILayout.Height(EditorGUIUtility.singleLineHeight);
            foreach (var listenerName in listenerNames)
            {
                EditorGUILayout.SelectableLabel(listenerName, EditorStyles.textField, height);
            }
        }

        #endregion

        #region Private Utility Methods

        private static GUIContent CreateLabelContent(string fieldName)
        {
            var text = ObjectNames.NicifyVariableName(fieldName);
            var tooltip = typeof(BaseScriptableEvent<>).GetTooltip(fieldName);

            return new GUIContent(text, tooltip);
        }

        private void GetListeners(out List<Object> objectListeners, out List<string> namedListeners)
        {
            objectListeners = new List<Object>();
            namedListeners = new List<string>();

            foreach (var listener in baseScriptableEvent.Listeners)
            {
                if (listener is Object listenerObject)
                {
                    objectListeners.Add(listenerObject);
                }
                else
                {
                    var listenerName = listener.ToString();
                    namedListeners.Add(listenerName);
                }
            }
        }

        #endregion
    }
}
