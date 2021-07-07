using ScriptableEvents.Events;
using UnityEditor;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(StringScriptableEvent))]
    public class StringScriptableEventEditor : BaseScriptableEventEditor<string>
    {
        protected override string DrawArgField(string value)
        {
            return EditorGUILayout.TextField(value);
        }
    }
}
