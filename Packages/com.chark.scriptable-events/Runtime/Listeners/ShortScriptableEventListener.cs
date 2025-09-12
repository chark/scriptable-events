using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Short Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent
    )]
    public sealed class ShortScriptableEventListener : ScriptableEventListener<short>
    {
    }
}
