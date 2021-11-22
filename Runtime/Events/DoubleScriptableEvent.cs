using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "DoubleScriptableEvent",
        menuName = ScriptableEventConstants.MenuNamePrefix + "/Double Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 4
    )]
    public class DoubleScriptableEvent : BaseScriptableEvent<double>
    {
    }
}
