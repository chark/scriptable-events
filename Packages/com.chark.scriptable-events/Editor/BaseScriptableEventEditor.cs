using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableEvents.Editor
{
    /// <summary>
    /// Base editor for all Scriptable Events.
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

        private GUILayoutOption listenerNameOption;

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
            DrawListenerLabel();
            DrawListenerStats();
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

        /// <summary>
        /// Draws a single listener field.
        /// </summary>
        internal virtual void DrawListener(object listener, int listenerIndex)
        {
            if (listener is Object listenerObject)
            {
                DrawListenerObject(listenerObject);
            }
            else
            {
                var listenerName = listener.ToString();
                DrawListenerName(listenerName);
            }
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
            SetupListenerNameOption();
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

        private void SetupListenerNameOption()
        {
            listenerNameOption = GUILayout.Height(EditorGUIUtility.singleLineHeight);
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

        private void DrawListenerLabel()
        {
            EditorGUILayout.LabelField(listenerLabelContent);
        }

        private void DrawListenerStats()
        {
            if (baseScriptableEvent.ListenerCount == 0)
            {
                EditorGUILayout.HelpBox(
                    "There are no listeners added to this event",
                    MessageType.Info
                );

                return;
            }

            GetListenerCounts(out var objectListenerCount, out var otherListenerCount);

            EditorGUILayout.LabelField(
                $"Event contains {objectListenerCount} UnityEngine.Object listeners and " +
                $"{otherListenerCount} other listeners",
                listenerSubLabelStyle
            );
        }

        private void DrawListeners()
        {
            var listenerIndex = 0;
            foreach (var listener in baseScriptableEvent.Listeners)
            {
                EditorGUILayout.BeginHorizontal();
                DrawListener(listener, listenerIndex);
                EditorGUILayout.EndHorizontal();

                listenerIndex++;
            }
        }

        private static void DrawListenerObject(Object listenerObject)
        {
            EditorGUILayout.ObjectField(listenerObject, null, false);
        }

        private void DrawListenerName(string listenerName)
        {
            EditorGUILayout.SelectableLabel(
                listenerName,
                EditorStyles.textField,
                listenerNameOption
            );
        }

        #endregion

        #region Private Utility Methods

        private static GUIContent CreateLabelContent(string fieldName)
        {
            var text = ObjectNames.NicifyVariableName(fieldName);
            var tooltip = typeof(BaseScriptableEvent<>).GetTooltip(fieldName);

            return new GUIContent(text, tooltip);
        }

        private void GetListenerCounts(out int objectListenerCount, out int otherListenerCount)
        {
            objectListenerCount = 0;
            otherListenerCount = 0;

            foreach (var listener in baseScriptableEvent.Listeners)
            {
                if (listener is Object)
                {
                    objectListenerCount++;
                }
                else
                {
                    otherListenerCount++;
                }
            }
        }

        #endregion
    }
}
