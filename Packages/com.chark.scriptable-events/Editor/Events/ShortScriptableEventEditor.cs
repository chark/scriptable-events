using CHARK.ScriptableEvents.Events;
using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(ShortScriptableEvent))]
    public class ShortScriptableEventEditor : ScriptableEventEditor<short>
    {
        protected override short DrawArgField(short value)
        {
            return ScriptableEventGUI.ShortField(value);
        }
    }
}
