using CHARK.ScriptableEvents.Events;
using UnityEditor;

namespace CHARK.ScriptableEvents.Editor.Events
{
    [CustomEditor(typeof(ByteScriptableEvent))]
    public class ByteScriptableEventEditor : ScriptableEventEditor<byte>
    {
        protected override byte DrawArgField(byte value)
        {
            return ScriptableEventGUI.ByteField(value);
        }
    }
}
