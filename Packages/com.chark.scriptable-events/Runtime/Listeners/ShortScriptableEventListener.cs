using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Short Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 1
    )]
    public sealed class ShortScriptableEventListener : ScriptableEventListener<short>
    {
    }
}
