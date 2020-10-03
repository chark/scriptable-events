using GameEvents.Generic;
using UnityEditor;
using UnityEngine;

namespace GameEvents.Game
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        #region Pirvate Fields

        private const int GroupSpacingPixels = 8;

        #endregion

        #region Public Methods

        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var gameEvent = target as GameEvent;
            if (gameEvent == null)
            {
                return;
            }

            GUI.enabled = Application.isPlaying;
            GUILayout.Space(GroupSpacingPixels);

            DrawRaise(gameEvent);
        }

        private static void DrawRaise(IGameEvent gameEvent)
        {
            GUILayout.Label("Raise event (play mode only)");
            if (GUILayout.Button("Raise"))
            {
                gameEvent.RaiseGameEvent();
            }
        }

        #endregion
    }
}
