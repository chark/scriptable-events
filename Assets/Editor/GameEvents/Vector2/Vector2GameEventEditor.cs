using GameEvents.Generic;
using UnityEditor;
using UnityEngine;

namespace GameEvents.Vector2
{
    [CustomEditor(typeof(Vector3GameEvent))]
    public class Vector2GameEventEditor
        : ArgumentGameEventEditor<Vector3GameEvent, UnityEngine.Vector2>
    {
        protected override UnityEngine.Vector2 DrawArgumentField(UnityEngine.Vector2 value)
        {
            return EditorGUILayout.Vector2Field(GUIContent.none, value);
        }
    }
}
