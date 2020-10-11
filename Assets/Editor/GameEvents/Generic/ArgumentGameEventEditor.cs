using UnityEditor;
using UnityEngine;

namespace GameEvents.Generic
{
    [CanEditMultipleObjects]
    public abstract class ArgumentGameEventEditor<TGameEvent, TArgument> : Editor
        where TGameEvent : class, IArgumentGameEvent<TArgument>
    {
        private const int GroupSpacingPixels = 8;

        private TArgument argumentValue = default;

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!(target is TGameEvent gameEvent))
            {
                return;
            }

            GUI.enabled = Application.isPlaying;
            GUILayout.Space(GroupSpacingPixels);

            DrawRaise(gameEvent);

            if (!Application.isPlaying)
            {
                return;
            }

            GUILayout.Space(GroupSpacingPixels);
            DrawListeners(gameEvent);
        }

        private void DrawRaise(TGameEvent gameEvent)
        {
            GUILayout.Label("Raise event (play mode only)");
            GUILayout.BeginHorizontal();

            argumentValue = DrawArgumentField(argumentValue);
            if (GUILayout.Button("Raise"))
            {
                gameEvent.RaiseGameEvent(argumentValue);
            }

            GUILayout.EndHorizontal();
        }

        private static void DrawListeners(TGameEvent gameEvent)
        {
            GUILayout.Label("Listeners");
            foreach (var listener in gameEvent.Listeners)
            {
                if (listener is MonoBehaviour behaviour)
                {
                    EditorGUILayout.ObjectField(behaviour, typeof(Object), true);
                }
            }
        }

        /// <returns>
        ///     Value that is entered in the argument field.
        /// </returns>
        protected abstract TArgument DrawArgumentField(TArgument value);
    }
}
