using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "DoubleScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Double Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 4
    )]
    public class DoubleScriptableEvent : BaseScriptableEvent<double>
    {
    }
}
