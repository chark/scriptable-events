using GameEvents.Vector3;
using UnityEditor;
using UnityEngine;

namespace GameEvents.Editor
{
    [CustomEditor(typeof(Vector3GameEvent))]
    public class Vector3GameEventEditor
        : BaseGameEventEditor<Vector3GameEvent, UnityEngine.Vector3>
    {
        protected override UnityEngine.Vector3 DrawArgField(UnityEngine.Vector3 value)
        {
            return EditorGUILayout.Vector3Field(GUIContent.none, value);
        }
    }
}
