using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Short Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 2
    )]
    public sealed class ShortScriptableEventListener : ScriptableEventListener<short>
    {
    }
}
