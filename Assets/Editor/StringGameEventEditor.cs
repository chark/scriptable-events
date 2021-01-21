using GameEvents.String;
using UnityEditor;

namespace GameEvents.Editor
{
    [CustomEditor(typeof(StringGameEvent))]
    public class StringGameEventEditor : BaseGameEventEditor<StringGameEvent, string>
    {
        protected override string DrawArgField(string value)
        {
            return EditorGUILayout.TextField(value);
        }
    }
}
