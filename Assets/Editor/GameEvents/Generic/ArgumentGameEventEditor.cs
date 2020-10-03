using UnityEditor;
using UnityEngine;

namespace GameEvents.Generic
{
    [CanEditMultipleObjects]
    public abstract class ArgumentGameEventEditor<TGameEvent, TArgument>
        : Editor where TGameEvent : class, IArgumentGameEvent<TArgument>
    {
        #region Protected Methods

        /// <returns>
        ///     Value that is entered in the argument field.
        /// </returns>
        protected virtual TArgument DrawArgumentField(TArgument value)
        {
            return value;
        }

        #endregion

        #region Pirvate Fields

        private const int GroupSpacingPixels = 8;

        private TArgument argumentValue = default;

        #endregion

        #region Public Methods

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (!(target is TGameEvent gameEvent)) return;

            GUI.enabled = Application.isPlaying;
            GUILayout.Space(GroupSpacingPixels);

            DrawRaise(gameEvent);
        }

        private void DrawRaise(TGameEvent gameEvent)
        {
            GUILayout.Label("Raise event (play mode only)");
            GUILayout.BeginHorizontal();

            argumentValue = DrawArgumentField(argumentValue);
            if (GUILayout.Button("Raise")) gameEvent.RaiseGameEvent(argumentValue);

            GUILayout.EndHorizontal();
        }

        #endregion
    }
}
