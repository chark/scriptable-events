using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    [CanEditMultipleObjects]
    public abstract class BaseScriptableEventEditor<TScriptableEvent, TArg>
        : UnityEditor.Editor
        where TScriptableEvent : ScriptableObject, IScriptableEvent<TArg>
    {
        #region Fields

        private TScriptableEvent scriptableEvent;
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

        // ReSharper disable once StaticMemberInGenericType
        private static readonly GUIContent DescriptionLabelContent = new GUIContent(
            "Description",
            "Custom description to provide more additional information"
        );

        // ReSharper disable once StaticMemberInGenericType
        private static readonly GUIContent SuppressExceptionsLabelContent = new GUIContent(
            "Suppress Exceptions",
            "Should exceptions not break the listener chain"
        );

        // ReSharper disable once StaticMemberInGenericType
        private static readonly GUIContent TraceLabelContent = new GUIContent(
            "Trace",
            "Should additional trace information be logged"
        );

        // ReSharper disable once StaticMemberInGenericType
        private static readonly GUIContent RaiseLabelContent = new GUIContent(
            "Raise event",
            "Raise event and trigger added listeners (play mode only)"
        );

        // ReSharper disable once StaticMemberInGenericType
        private static readonly GUIContent ListenerLabelContent = new GUIContent(
            "Added listeners",
            "Added listeners to this event (play mode only)"
        );

        private TArg argValue;

        #endregion

        #region Unity Lifecycle

        public void OnEnable()
        {
            scriptableEvent = target as TScriptableEvent;
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

        private void DrawMonoScript()
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", monoScript, typeof(TScriptableEvent), false);
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
                var descriptionLabelSize = EditorStyles.label.CalcSize(DescriptionLabelContent);
                descriptionWidth = descriptionLabelSize.x;
            }
        }

        private void DrawDescription()
        {
            // Label.
            EditorGUILayout.LabelField(DescriptionLabelContent);

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
                SuppressExceptionsLabelContent,
                suppressExceptionsProperty.boolValue
            );
        }

        private void DrawTrace()
        {
            traceProperty.boolValue = EditorGUILayout.Toggle(
                TraceLabelContent,
                traceProperty.boolValue
            );
        }

        private void DrawRaise()
        {
            // Label.
            EditorGUILayout.LabelField(RaiseLabelContent);
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
            EditorGUILayout.LabelField(ListenerLabelContent);

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
