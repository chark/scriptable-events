using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ByteScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Byte Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 1
    )]
    public sealed class ByteScriptableEvent : ScriptableEvent<byte>
    {
    }
}
