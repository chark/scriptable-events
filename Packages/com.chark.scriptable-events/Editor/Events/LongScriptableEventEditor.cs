using CHARK.ScriptableEvents.Events;
using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(LongScriptableEvent))]
    public class LongScriptableEventEditor : ScriptableEventEditor<long>
    {
        protected override long DrawArgField(long value)
        {
            return ScriptableEventGUI.LongField(value);
        }
    }
}
