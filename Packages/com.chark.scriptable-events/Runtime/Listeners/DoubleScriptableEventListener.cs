using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Double Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 4
    )]
    public class DoubleScriptableEventListener : BaseScriptableEventListener<double>
    {
    }
}
