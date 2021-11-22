using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNamePrefix + "/Double Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 4
    )]
    public class DoubleScriptableEventListener : BaseScriptableEventListener<double>
    {
    }
}
