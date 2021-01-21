using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace GameEvents.Editor
{
    [CanEditMultipleObjects]
    public abstract class BaseGameEventEditor<TGameEvent, TArg>
        : UnityEditor.Editor
        where TGameEvent : class, IGameEvent<TArg>
    {
        #region Fields

        private SerializedProperty descriptionField;
        private TArg argValue;

        #endregion

        #region Unity Lifecycle

        public void OnEnable()
        {
            // todo: add locking https://github.com/roboryantron/Unite2017/blob/master/Assets/Code/Variables/Editor/FloatReferenceDrawer.cs
            descriptionField = serializedObject.FindProperty("description");
        }

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!(target is TGameEvent gameEvent))
            {
                return;
            }

            GUI.enabled = Application.isPlaying;
            EditorGUILayout.Space();

            DrawRaise(gameEvent);

            EditorGUILayout.Space();
            DrawReferences(gameEvent);
        }

        #endregion

        #region Methods

        private void DrawRaise(TGameEvent gameEvent)
        {
            DrawPlaymodeLabel("Raise event");
            GUILayout.BeginHorizontal();

            argValue = DrawArgField(argValue);
            if (GUILayout.Button("Raise"))
            {
                gameEvent.Raise(argValue);
            }

            GUILayout.EndHorizontal();
        }

        /// <returns>
        /// Value that is entered in the game event argument field.
        /// </returns>
        protected abstract TArg DrawArgField(TArg value);

        private static void DrawReferences<TArgument>(IGameEvent<TArgument> gameEvent)
        {
            DrawListeners(gameEvent.Listeners);
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
                        EditorGUILayout.ObjectField(behaviour, typeof(UnityEngine.Object), true);
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
