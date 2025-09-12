using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "DoubleScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Double Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent
    )]
    public sealed class DoubleScriptableEvent : ScriptableEvent<double>
    {
    }
}
