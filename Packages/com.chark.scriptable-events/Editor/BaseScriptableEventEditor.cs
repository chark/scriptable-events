using System.Collections;
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
        private ScriptableObject rawScriptableEvent;
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
            descriptionLabelContent = CreateLabelContent("description");
            suppressExceptionsLabelContent = CreateLabelContent("suppressExceptions");
            traceLabelContent = CreateLabelContent("trace");
            listenerLabelContent = new GUIContent(
                "Added Listeners",
                "Added listeners to this event (play mode only)"
            );

            rawScriptableEvent = target as ScriptableObject;
            monoScript = MonoScript.FromScriptableObject(rawScriptableEvent);

            descriptionProperty = serializedObject.FindProperty("description");
            lockDescriptionProperty = serializedObject.FindProperty("lockDescription");
            suppressExceptionsProperty = serializedObject.FindProperty("suppressExceptions");
            traceProperty = serializedObject.FindProperty("trace");
        }

        public override void OnInspectorGUI()
        {
            DrawMonoScript();
            SetupStyles();

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

            DrawListeners();
        }

        #endregion

        #region Internal Methods

        internal virtual void DrawAdditionalProperties()
        {
        }

        #endregion

        #region Private Methods

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

        private void DrawMonoScript()
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", monoScript, rawScriptableEvent.GetType(), false);
            GUI.enabled = true;
        }

        private void SetupStyles()
        {
            if (descriptionLockStyle == null)
            {
                descriptionLockStyle = GUI.skin.GetStyle("IN LockButton");
            }

            if (descriptionStyle == null)
            {
                descriptionStyle = new GUIStyle(EditorStyles.textArea)
                {
                    richText = true,
                    wordWrap = true
                };
            }

            if (descriptionWidth <= 0)
            {
                var descriptionLabelSize = EditorStyles.label.CalcSize(descriptionLabelContent);
                descriptionWidth = descriptionLabelSize.x;
            }

            if (listenerSubLabelStyle == null)
            {
                var labelSkin = GUI.skin.label;
                listenerSubLabelStyle = new GUIStyle(labelSkin)
                {
                    fontSize = (int) (labelSkin.fontSize * 0.9f),
                    wordWrap = true
                };
            }
        }

        private void DrawDescription()
        {
            // Label.
            EditorGUILayout.LabelField(descriptionLabelContent);

            // Label position.
            var position = GUILayoutUtility.GetLastRect();
            position.width = descriptionLockStyle.fixedWidth;
            position.x = position.xMin + descriptionWidth;

            // Lock button.
            lockDescriptionProperty.boolValue = EditorGUI.Toggle(
                position,
                GUIContent.none,
                lockDescriptionProperty.boolValue,
                descriptionLockStyle
            );

            // Text.
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
            CountListeners(out var listenerObjectCount, out var listenerRawCount);
            if (listenerObjectCount == 0 && listenerRawCount == 0)
            {
                EditorGUILayout.HelpBox(
                    "There are no listeners added to this event",
                    MessageType.Warning
                );

                return;
            }

            EditorGUILayout.LabelField(
                $"This event contains {listenerObjectCount} UnityEngine.Object listeners and " +
                $"{listenerRawCount} other listeners",
                listenerSubLabelStyle
            );

            DrawListenerFields();
        }

        private void CountListeners(out int listenerObjectCount, out int listenerRawCount)
        {
            listenerObjectCount = 0;
            listenerRawCount = 0;

            foreach (var listener in GetListeners())
            {
                if (listener is Object)
                {
                    listenerObjectCount++;
                }
                else
                {
                    listenerRawCount++;
                }
            }
        }

        private void DrawListenerFields()
        {
            foreach (var listener in GetListeners())
            {
                if (listener is Object listenerObject)
                {
                    EditorGUILayout.ObjectField(listenerObject, typeof(Object), true);
                }
            }
        }

        private IEnumerable GetListeners()
        {
            var baseScriptableEventType = rawScriptableEvent.GetType().BaseType;

            // ReSharper disable once PossibleNullReferenceException
            var listenersField = baseScriptableEventType.GetField(
                "listeners",
                BindingFlags.Instance | BindingFlags.NonPublic
            );

            // ReSharper disable once PossibleNullReferenceException
            var listeners = listenersField.GetValue(rawScriptableEvent) as IEnumerable;

            return listeners;
        }

        #endregion
    }
}
