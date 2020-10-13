using System.Collections.Generic;
using GameEvents.Generic;
using UnityEditor;
using UnityEngine;

namespace GameEvents
{
    public static class GameEventEditors
    {
        /// <summary>
        ///     Draw a list of argument game event listener references.
        /// </summary>
        public static void DrawReferences<TArgument>(
            IArgumentGameEvent<TArgument> gameEvent
        )
        {
            DrawListeners(gameEvent.Listeners);
        }

        /// <summary>
        ///     Draw a list of game event listener references.
        /// </summary>
        public static void DrawReferences(IGameEvent gameEvent)
        {
            DrawListeners(gameEvent.Listeners);
        }

        /// <summary>
        ///     Draw a label which changes its suffix based on play mode state.
        /// </summary>
        public static void DrawPlaymodeLabel(string text)
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
                        "There are no listeners on this event",
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
    }
}
