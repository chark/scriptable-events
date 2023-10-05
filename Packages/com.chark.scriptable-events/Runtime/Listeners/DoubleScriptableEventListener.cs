using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Double Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 4
    )]
    public sealed class DoubleScriptableEventListener : ScriptableEventListener<double>
    {
    }
}
