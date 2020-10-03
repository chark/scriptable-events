using GameEvents.Generic;
using UnityEditor;

namespace GameEvents.String
{
    [CustomEditor(typeof(StringGameEvent))]
    public class StringGameEventEditor : ArgumentGameEventEditor<StringGameEvent, string>
    {
        protected override string DrawArgumentField(string value)
        {
            return EditorGUILayout.TextField(value);
        }
    }
}
