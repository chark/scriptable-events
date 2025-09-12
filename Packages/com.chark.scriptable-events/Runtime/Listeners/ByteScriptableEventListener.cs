using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Byte Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent
    )]
    public sealed class ByteScriptableEventListener : ScriptableEventListener<byte>
    {
    }
}
