using GameEvents.Vector2;
using UnityEditor;
using UnityEngine;

namespace GameEvents.Editor
{
    [CustomEditor(typeof(Vector2GameEvent))]
    public class Vector2GameEventEditor
        : BaseGameEventEditor<Vector2GameEvent, UnityEngine.Vector2>
    {
        protected override UnityEngine.Vector2 DrawArgField(UnityEngine.Vector2 value)
        {
            return EditorGUILayout.Vector2Field(GUIContent.none, value);
        }
    }
}
