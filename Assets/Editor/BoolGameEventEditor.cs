using GameEvents.Bool;
using UnityEditor;

namespace GameEvents.Editor
{
    [CustomEditor(typeof(BoolGameEvent))]
    public class BoolGameEventEditor : BaseGameEventEditor<BoolGameEvent, bool>
    {
        protected override bool DrawArgField(bool value)
        {
            return EditorGUILayout.Toggle(value);
        }
    }
}
