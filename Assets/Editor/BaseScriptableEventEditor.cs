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


        private TArg argValue;

        #endregion

        #region Unity Lifecycle

        public void OnEnable()
        {
            // todo: add locking https://github.com/roboryantron/Unite2017/blob/master/Assets/Code/Variables/Editor/FloatReferenceDrawer.cs
            descriptionProperty = serializedObject.FindProperty("description");
            lockDescription = serializedObject.FindProperty("lockDescription");
        }

        public override void OnInspectorGUI()
        {
            GUI.enabled = false;
            EditorGUILayout.ObjectField("Script", MonoScript.FromScriptableObject(target as ScriptableObject), typeof(TScriptableEvent), false);
            GUI.enabled = true;

            EditorGUI.BeginChangeCheck();

            // Description.
            EditorGUILayout.LabelField("Description");
            var descriptionLabelRect = GUILayoutUtility.GetLastRect();

            var lockStyle = GUI.skin.GetStyle("IN LockButton");
            descriptionLabelRect.x = descriptionLabelRect.xMin + EditorStyles.label.CalcSize(new GUIContent("Description")).x;
            descriptionLabelRect.width = lockStyle.fixedWidth;
            lockDescription.boolValue = EditorGUI.Toggle(descriptionLabelRect, GUIContent.none, lockDescription.boolValue, lockStyle);

            GUI.enabled = !lockDescription.boolValue;
            var style = new GUIStyle(EditorStyles.textArea);
            style.richText = true;
            descriptionProperty.stringValue = EditorGUILayout.TextArea(descriptionProperty.stringValue, style);
            GUI.enabled = true;

            // Description lock.

            if (EditorGUI.EndChangeCheck())
            {
                serializedObject.ApplyModifiedProperties();
            }

            DrawPropertiesExcluding(serializedObject, descriptionProperty.name, lockDescription.name);

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
