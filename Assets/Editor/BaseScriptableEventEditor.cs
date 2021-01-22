using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace ScriptableEvents.Editor
{
    [CanEditMultipleObjects]
    public abstract class BaseScriptableEventEditor<TScriptableEvent, TArg>
        : UnityEditor.Editor
        where TScriptableEvent : class, IScriptableEvent<TArg>
    {
        #region Fields

        private SerializedProperty descriptionProperty;
        private SerializedProperty lockDescription;

        private MonoScript monoScript;

        // Cached description styles.
        private GUIStyle descriptionLockStyle;
        private GUIStyle descriptionStyle;
        private float descriptionWidth;

        private TArg argValue;

        #endregion

        #region Unity Lifecycle

        public void OnEnable()
        {
            descriptionProperty = serializedObject.FindProperty("description");
            lockDescription = serializedObject.FindProperty("lockDescription");

            monoScript = MonoScript.FromScriptableObject(target as ScriptableObject);
        }

        private void DrawMonoScript()
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", monoScript, typeof(TScriptableEvent), false);
            GUI.enabled = true;
        }

        private void SetupDescriptionStyles()
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
                descriptionWidth = EditorStyles.label.CalcSize(new GUIContent("Description")).x;
            }
        }

        private void DrawDescription()
        {
            // Label.
            EditorGUILayout.LabelField("Description");

            // Label position.
            var position = GUILayoutUtility.GetLastRect();
            position.width = descriptionLockStyle.fixedWidth;
            position.x = position.xMin + descriptionWidth;

            // Lock button.
            lockDescription.boolValue = EditorGUI.Toggle(
                position,
                GUIContent.none,
                lockDescription.boolValue,
                descriptionLockStyle
            );

            // Text.
            GUI.enabled = !lockDescription.boolValue;
            descriptionProperty.stringValue = EditorGUILayout.TextArea(
                descriptionProperty.stringValue,
                descriptionStyle
            );

            GUI.enabled = true;
        }

        public override void OnInspectorGUI()
        {
            DrawMonoScript();

            EditorGUI.BeginChangeCheck();

            SetupDescriptionStyles();
            DrawDescription();

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }

            DrawPropertiesExcluding(serializedObject, descriptionProperty.name,
                lockDescription.name);

            return;

            base.OnInspectorGUI();

            if (!(target is TScriptableEvent ScriptableEvent))
            {
                return;
            }

            GUI.enabled = Application.isPlaying;
            EditorGUILayout.Space();

            DrawRaise(ScriptableEvent);

            EditorGUILayout.Space();
            DrawReferences(ScriptableEvent);
        }

        #endregion

        #region Methods

        private void DrawRaise(TScriptableEvent scriptableEvent)
        {
            DrawPlaymodeLabel("Raise event");
            GUILayout.BeginHorizontal();

            argValue = DrawArgField(argValue);
            if (GUILayout.Button("Raise"))
            {
                scriptableEvent.Raise(argValue);
            }

            GUILayout.EndHorizontal();
        }

        /// <returns>
        /// Value that is entered in the Scriptable Event argument field.
        /// </returns>
        protected abstract TArg DrawArgField(TArg value);

        private static void DrawReferences<TArgument>(IScriptableEvent<TArgument> scriptableEvent)
        {
            DrawListeners(scriptableEvent.Listeners);
        }

        private static void DrawPlaymodeLabel(string text)
        {
            var labelSuffix = Application.isPlaying ? "" : "(play mode only)";
            GUILayout.Label($"{text} {labelSuffix}");
        }

        private static void DrawListeners<T>(ICollection<T> listeners)
        {
            DrawPlaymodeLabel("Listeners");
            if (Application.isPlaying)
            {
                if (listeners.Count == 0)
                {
                    EditorGUILayout.HelpBox(
                        "There are no listeners listening for this event",
                        MessageType.Warning
                    );

                    return;
                }

                foreach (var listener in listeners)
                {
                    if (listener is MonoBehaviour behaviour)
                    {
                        EditorGUILayout.ObjectField(behaviour, typeof(Object), true);
                    }
                }
            }
            else
            {
                EditorGUILayout.HelpBox(
                    "Registered listeners will be displayed here",
                    MessageType.Info
                );
            }
        }

        #endregion
    }
}
