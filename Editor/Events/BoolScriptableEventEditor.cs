using CHARK.ScriptableEvents.Events;
using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(BoolScriptableEvent))]
    public class BoolScriptableEventEditor : BaseScriptableEventEditor<bool>
    {
        protected override bool DrawArgField(bool value)
        {
            return ScriptableEventGUI.Toggle(value);
        }
    }
}
