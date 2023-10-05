using CHARK.ScriptableEvents.Events;
using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(IntScriptableEvent))]
    public class IntScriptableEventEditor : BaseScriptableEventEditor<int>
    {
        protected override int DrawArgField(int value)
        {
            return ScriptableEventGUI.IntField(value);
        }
    }
}
