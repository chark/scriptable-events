using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/String Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 5
    )]
    public sealed class StringScriptableEventListener : ScriptableEventListener<string>
    {
    }
}
