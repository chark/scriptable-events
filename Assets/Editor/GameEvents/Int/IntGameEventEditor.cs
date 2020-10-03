using GameEvents.Generic;
using UnityEditor;

namespace GameEvents.Int
{
    [CustomEditor(typeof(IntGameEvent))]
    public class IntGameEventEditor : ArgumentGameEventEditor<IntGameEvent, int>
    {
        protected override int DrawArgumentField(int value)
        {
            return EditorGUILayout.IntField(value);
        }
    }
}
