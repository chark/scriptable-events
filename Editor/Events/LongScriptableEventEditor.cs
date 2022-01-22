using ScriptableEvents.Events;
using UnityEditor;

namespace ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(LongScriptableEvent))]
    public class LongScriptableEventEditor : BaseScriptableEventEditor<long>
    {
        protected override long DrawArgField(long value)
        {
            return ScriptableEventGUI.LongField(value);
        }
    }
}
