using CHARK.ScriptableEvents.Events;
using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(IntScriptableEvent))]
    public class IntScriptableEventEditor : ScriptableEventEditor<int>
    {
        protected override int DrawArgField(int value)
        {
            return ScriptableEventGUI.IntField(value);
        }
    }
}
