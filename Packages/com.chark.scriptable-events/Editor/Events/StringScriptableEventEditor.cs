using CHARK.ScriptableEvents.Events;
using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(StringScriptableEvent))]
    public class StringScriptableEventEditor : ScriptableEventEditor<string>
    {
        protected override string DrawArgField(string value)
        {
            return ScriptableEventGUI.TextField(value);
        }
    }
}
