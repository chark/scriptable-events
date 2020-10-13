using GameEvents.Generic;
using UnityEditor;
using UnityEngine;

namespace GameEvents.Game
{
    [CanEditMultipleObjects]
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var gameEvent = target as GameEvent;
            if (gameEvent == null)
            {
                return;
            }

            GUI.enabled = Application.isPlaying;
            EditorGUILayout.Space();

            DrawRaise(gameEvent);

            if (!Application.isPlaying)
            {
                return;
            }

            EditorGUILayout.Space();
            GameEventEditors.DrawReferences(gameEvent);
        }

        private static void DrawRaise(IGameEvent gameEvent)
        {
            GameEventEditors.DrawPlaymodeLabel("Raise event");
            if (GUILayout.Button("Raise"))
            {
                gameEvent.RaiseGameEvent();
            }
        }
    }
}
