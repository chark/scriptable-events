using GameEvents.Int;
using UnityEditor;

namespace GameEvents.Editor
{
    [CustomEditor(typeof(IntGameEvent))]
    public class IntGameEventEditor : BaseGameEventEditor<IntGameEvent, int>
    {
        protected override int DrawArgField(int value)
        {
            return EditorGUILayout.IntField(value);
        }
    }
}
