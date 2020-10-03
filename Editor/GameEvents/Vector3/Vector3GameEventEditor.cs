using GameEvents.Generic;
using UnityEditor;
using UnityEngine;

namespace GameEvents.Vector3
{
    [CustomEditor(typeof(Vector3GameEvent))]
    public class Vector3GameEventEditor
        : ArgumentGameEventEditor<Vector3GameEvent, UnityEngine.Vector3>
    {
        protected override UnityEngine.Vector3 DrawArgumentField(UnityEngine.Vector3 value)
        {
            return EditorGUILayout.Vector3Field(GUIContent.none, value);
        }
    }
}
