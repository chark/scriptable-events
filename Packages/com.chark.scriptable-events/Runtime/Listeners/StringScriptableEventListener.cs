using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/String Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 7
    )]
    public sealed class StringScriptableEventListener : ScriptableEventListener<string>
    {
    }
}
