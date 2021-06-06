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

        // Reflection.
        private const BindingFlags PrivateFieldBindingFlags =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

        // Labels.
        private GUIContent descriptionLabelContent;
        private GUIContent suppressExceptionsLabelContent;
        private GUIContent traceLabelContent;
        private GUIContent listenerLabelContent;

        // Target properties.
        private ScriptableObject scriptableEvent;
        private MonoScript monoScript;

        // Cached properties.
        private SerializedProperty descriptionProperty;
        private SerializedProperty lockDescriptionProperty;
        private SerializedProperty suppressExceptionsProperty;
        private SerializedProperty traceProperty;

        // Cached styles.
        private GUIStyle descriptionLockStyle;
        private GUIStyle descriptionStyle;
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

            scriptableEvent = target as ScriptableObject;
            monoScript = MonoScript.FromScriptableObject(scriptableEvent);

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

            // ReSharper disable once AssignNullToNotNullAttribute
            var tooltip = typeof(BaseScriptableEvent<>)
                .GetField(fieldName, PrivateFieldBindingFlags)
                .GetCustomAttribute<TooltipAttribute>()
                .tooltip;

            return new GUIContent(text, tooltip);
        }

        private void DrawMonoScript()
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", monoScript, scriptableEvent.GetType(), false);
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
                var baseScriptableEventType = scriptableEvent.GetType().BaseType;

                // ReSharper disable once PossibleNullReferenceException
                var listenersField = baseScriptableEventType
                    .GetField("listeners", BindingFlags.Instance | BindingFlags.NonPublic);

                // ReSharper disable once PossibleNullReferenceException
                var listeners = listenersField
                    .GetValue(scriptableEvent) as IEnumerable;

                var listenerCount = 0;

                // ReSharper disable once PossibleNullReferenceException
                foreach (var listener in listeners)
                {
                    if (listener is MonoBehaviour behaviour)
                    {
                        EditorGUILayout.ObjectField(behaviour, typeof(Object), true);
                    }

                    listenerCount++;
                }

                if (listenerCount == 0)
                {
                    EditorGUILayout.HelpBox(
                        "There are no listeners added to this event",
                        MessageType.Warning
                    );
                }
            }
            else
            {
                EditorGUILayout.HelpBox(
                    "Added listeners will be displayed here",
                    MessageType.Info
                );
            }
        }

        #endregion
    }
}
