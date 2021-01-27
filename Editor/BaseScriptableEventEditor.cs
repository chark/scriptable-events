using System.Reflection;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableEvents.Editor
{
    [CanEditMultipleObjects]
    public abstract class BaseScriptableEventEditor<TArg> : UnityEditor.Editor
    {
        #region Fields

        // Reflection.
        private const BindingFlags PrivateFieldBindingFlags =
            BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.DeclaredOnly;

        // Labels.
        private GUIContent descriptionLabelContent;
        private GUIContent suppressExceptionsLabelContent;
        private GUIContent traceLabelContent;
        private GUIContent raiseLabelContent;
        private GUIContent listenerLabelContent;

        // Target properties.
        private BaseScriptableEvent<TArg> scriptableEvent;
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

        private TArg argValue;

        #endregion

        #region Unity Lifecycle

        public void OnEnable()
        {
            descriptionLabelContent = CreateLabelContent("description");
            suppressExceptionsLabelContent = CreateLabelContent("suppressExceptions");
            traceLabelContent = CreateLabelContent("trace");
            raiseLabelContent = new GUIContent(
                "Raise Event",
                "Raise event and trigger added listeners (play mode only)"
            );
            listenerLabelContent = new GUIContent(
                "Added Listeners",
                "Added listeners to this event (play mode only)"
            );

            scriptableEvent = target as BaseScriptableEvent<TArg>;
            monoScript = MonoScript.FromScriptableObject(scriptableEvent);

            descriptionProperty = serializedObject.FindProperty("description");
            lockDescriptionProperty = serializedObject.FindProperty("lockDescription");
            suppressExceptionsProperty = serializedObject.FindProperty("suppressExceptions");
            traceProperty = serializedObject.FindProperty("trace");
        }

        public override void OnInspectorGUI()
        {
            DrawMonoScript();

            EditorGUI.BeginChangeCheck();

            SetupStyles();
            DrawDescription();

            EditorGUILayout.Space();
            DrawSuppressExceptions();
            DrawTrace();

            EditorGUILayout.Space();
            DrawRaise();

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }

            EditorGUILayout.Space();
            DrawListeners();
        }

        #endregion

        #region Overrides

        /// <returns>
        /// Value that is entered in the event argument field.
        /// </returns>
        protected abstract TArg DrawArgField(TArg value);

        #endregion

        #region Methods

        private static GUIContent CreateLabelContent(string fieldName)
        {
            var text = ObjectNames.NicifyVariableName(fieldName);

            // ReSharper disable once AssignNullToNotNullAttribute
            var tooltip = typeof(BaseScriptableEvent<TArg>)
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

        private void DrawRaise()
        {
            // Label.
            EditorGUILayout.LabelField(raiseLabelContent);
            GUI.enabled = Application.isPlaying;

            // Edit mode input.
            GUILayout.BeginHorizontal();

            argValue = DrawArgField(argValue);
            if (GUILayout.Button("Raise"))
            {
                scriptableEvent.Raise(argValue);
            }

            GUILayout.EndHorizontal();
            GUI.enabled = true;
        }

        private void DrawListeners()
        {
            EditorGUILayout.LabelField(listenerLabelContent);

            // Edit mode info.
            if (!Application.isPlaying)
            {
                EditorGUILayout.HelpBox(
                    "Added listeners will be displayed here",
                    MessageType.Info
                );

                return;
            }

            // Play mode info.
            if (scriptableEvent.Listeners.Count == 0)
            {
                EditorGUILayout.HelpBox(
                    "There are no listeners added to this event",
                    MessageType.Warning
                );

                return;
            }

            foreach (var listener in scriptableEvent.Listeners)
            {
                if (listener is MonoBehaviour behaviour)
                {
                    EditorGUILayout.ObjectField(behaviour, typeof(Object), true);
                }
            }
        }

        #endregion
    }
}
