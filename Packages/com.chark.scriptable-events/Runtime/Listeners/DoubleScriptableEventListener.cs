using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Double Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 6
    )]
    public sealed class DoubleScriptableEventListener : ScriptableEventListener<double>
    {
    }
}
