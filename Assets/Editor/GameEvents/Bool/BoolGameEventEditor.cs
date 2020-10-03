using GameEvents.Generic;
using UnityEditor;

namespace GameEvents.Bool
{
    [CustomEditor(typeof(BoolGameEvent))]
    public class BoolGameEventEditor : ArgumentGameEventEditor<BoolGameEvent, bool>
    {
        protected override bool DrawArgumentField(bool value)
        {
            return EditorGUILayout.Toggle(value);
        }
    }
}
