using ScriptableEvents.String;
using UnityEditor;

namespace ScriptableEvents.Editor
{
    [CustomEditor(typeof(StringScriptableEvent))]
    public class StringScriptableEventEditor
        : BaseScriptableEventEditor<StringScriptableEvent, string>
    {
        protected override string DrawArgField(string value)
        {
            return EditorGUILayout.TextField(value);
        }
    }
}
