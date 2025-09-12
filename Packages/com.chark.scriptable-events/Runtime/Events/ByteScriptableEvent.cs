using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ByteScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Byte Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent
    )]
    public sealed class ByteScriptableEvent : ScriptableEvent<byte>
    {
    }
}
