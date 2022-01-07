using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableEvents.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(BaseScriptableEvent), true)]
    public class BaseScriptableEventEditor : UnityEditor.Editor
    {
        #region Fields

        // Labels.
        private GUIContent descriptionLabelContent;
        private GUIContent suppressExceptionsLabelContent;
        private GUIContent traceLabelContent;
        private GUIContent listenerLabelContent;

        // Target properties.
        private BaseScriptableEvent scriptableEvent;
        private MonoScript monoScript;

        // Cached properties.
        private SerializedProperty descriptionProperty;
        private SerializedProperty suppressExceptionsProperty;
        private SerializedProperty traceProperty;

        // Cached styles.
        private GUIStyle descriptionLockStyle;
        private GUIStyle descriptionStyle;
        private GUIStyle listenerSubLabelStyle;

        private float descriptionWidth;
        private bool isLockDescription = true;

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
            SetupStyles();

            DrawMonoScript();

            EditorGUI.BeginChangeCheck();
            DrawDescription();

            EditorGUILayout.Space();
            DrawSuppressExceptions();
            DrawTrace();
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

        internal virtual void DrawAdditionalProperties()
        {
        }

        #endregion

        #region Private Setup Methods

        private void SetupLabelContent()
        {
            descriptionLabelContent = CreateLabelContent("description");
            suppressExceptionsLabelContent = CreateLabelContent("suppressExceptions");
            traceLabelContent = CreateLabelContent("trace");
            listenerLabelContent = new GUIContent(
                "Added Listeners",
                "Added listeners to this event (play mode only)"
            );
        }

        private void SetupScriptableEvent()
        {
            scriptableEvent = target as BaseScriptableEvent;
        }

        private void SetupMonoScript()
        {
            monoScript = MonoScript.FromScriptableObject(scriptableEvent);
        }

        private void SetupSerializedProperties()
        {
            descriptionProperty = serializedObject.FindProperty("description");
            suppressExceptionsProperty = serializedObject.FindProperty("suppressExceptions");
            traceProperty = serializedObject.FindProperty("trace");
        }

        private void SetupStyles()
        {
            if (descriptionLockStyle == null)
            {
                SetupDescriptionLockStyle();
            }

            if (descriptionStyle == null)
            {
                SetupDescriptionStyle();
            }

            if (descriptionWidth <= 0)
            {
                SetupDescriptionWidth();
            }

            if (listenerSubLabelStyle == null)
            {
                SetupListenerSubLabelStyle();
            }
        }

        private void SetupDescriptionLockStyle()
        {
            descriptionLockStyle = GUI.skin.GetStyle("IN LockButton");
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
            DrawDescriptionTextArea();
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

        private void DrawDescriptionTextArea()
        {
            GUI.enabled = !isLockDescription;
            descriptionProperty.stringValue = EditorGUILayout.TextArea(
                descriptionProperty.stringValue,
                descriptionStyle
            );

            GUI.enabled = true;
        }

        private void DrawSuppressExceptions()
        {
            suppressExceptionsProperty.boolValue = EditorGUILayout.Toggle(
                suppressExceptionsLabelContent,
                suppressExceptionsProperty.boolValue
            );
        }

        private void DrawTrace()
        {
            traceProperty.boolValue = EditorGUILayout.Toggle(
                traceLabelContent,
                traceProperty.boolValue
            );
        }

        private void DrawListeners()
        {
            EditorGUILayout.LabelField(listenerLabelContent);

            if (Application.isPlaying)
            {
                DrawPlayModeListeners();
            }
            else
            {
                EditorGUILayout.HelpBox(
                    "Added listeners will be displayed here during playmode",
                    MessageType.Info
                );
            }
        }

        private void DrawPlayModeListeners()
        {
            GetListeners(out var objectListeners, out var otherListeners);

            var listenerCount = objectListeners.Count + otherListeners.Count;
            if (listenerCount == 0)
            {
                EditorGUILayout.HelpBox(
                    "There are no listeners added to this event",
                    MessageType.Warning
                );

                return;
            }

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

            foreach (var listener in scriptableEvent.Listeners)
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
