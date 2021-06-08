using System.Collections.Generic;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(BaseScriptableEvent<>), true)]
    public class BaseScriptableEventEditor : UnityEditor.Editor
    {
        #region Fields

        // Labels.
        private GUIContent descriptionLabelContent;
        private GUIContent suppressExceptionsLabelContent;
        private GUIContent traceLabelContent;
        private GUIContent listenerLabelContent;

        // Target properties.
        private MonoScript monoScript;

        // Cached properties.
        private SerializedProperty descriptionProperty;
        private SerializedProperty lockDescriptionProperty;
        private SerializedProperty suppressExceptionsProperty;
        private SerializedProperty traceProperty;

        // Cached styles.
        private GUIStyle descriptionLockStyle;
        private GUIStyle descriptionStyle;
        private GUIStyle listenerSubLabelStyle;

        private float descriptionWidth;

        #endregion

        #region Unity Lifecycle

        internal virtual void OnEnable()
        {
            SetupLabelContent();
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

        #region Setup Methods

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

        private void SetupMonoScript()
        {
            var scriptableObject = target as ScriptableObject;
            monoScript = MonoScript.FromScriptableObject(scriptableObject);
        }

        private void SetupSerializedProperties()
        {
            descriptionProperty = serializedObject.FindProperty("description");
            lockDescriptionProperty = serializedObject.FindProperty("lockDescription");
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

            lockDescriptionProperty.boolValue = EditorGUI.Toggle(
                position,
                GUIContent.none,
                lockDescriptionProperty.boolValue,
                descriptionLockStyle
            );
        }

        private void DrawDescriptionTextArea()
        {
            GUI.enabled = !lockDescriptionProperty.boolValue;
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
            var listenerCount = GetPropertyValue<int>("ListenerCount");
            if (listenerCount == 0)
            {
                EditorGUILayout.HelpBox(
                    "There are no listeners added to this event",
                    MessageType.Warning
                );

                return;
            }

            var listenerObjects = GetPropertyValue<IReadOnlyList<Object>>("ListenerObjects");
            EditorGUILayout.LabelField(
                $"Event contains {listenerObjects.Count} UnityEngine.Object listeners and " +
                $"{listenerCount - listenerObjects.Count} other listeners",
                listenerSubLabelStyle
            );

            DrawListenerFields(listenerObjects);
        }

        private static void DrawListenerFields(IEnumerable<Object> listenerObjects)
        {
            foreach (var listenerObject in listenerObjects)
            {
                EditorGUILayout.ObjectField(listenerObject, typeof(Object), true);
            }
        }

        #endregion

        #region Private Utility Methods

        private static GUIContent CreateLabelContent(string fieldName)
        {
            var text = ObjectNames.NicifyVariableName(fieldName);
            var tooltip = GetTooltip(fieldName);

            return new GUIContent(text, tooltip);
        }

        private static string GetTooltip(string fieldName)
        {
            var field = typeof(BaseScriptableEvent<>)
                .GetField(
                    fieldName,
                    BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly
                );

            // ReSharper disable once AssignNullToNotNullAttribute
            var attribute = field
                .GetCustomAttribute<TooltipAttribute>();

            return attribute.tooltip;
        }

        private T GetPropertyValue<T>(string propertyName)
        {
            var baseType = target.GetType().BaseType;

            // ReSharper disable once PossibleNullReferenceException
            var property = baseType.GetProperty(
                propertyName,
                BindingFlags.NonPublic | BindingFlags.Instance
            );

            // ReSharper disable once PossibleNullReferenceException
            return (T) property.GetValue(target);
        }

        #endregion
    }
}
