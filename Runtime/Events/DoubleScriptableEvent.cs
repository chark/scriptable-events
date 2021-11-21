using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "DoubleScriptableEvent",
        menuName = "Scriptable Events/Double Scriptable Event",
        order = ScriptableEventConstants.PrimitiveScriptableEventOrder + 4
    )]
    public class DoubleScriptableEvent : BaseScriptableEvent<double>
    {
    }
}
