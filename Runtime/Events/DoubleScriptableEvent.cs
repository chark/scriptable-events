using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "DoubleScriptableEvent",
        menuName = "Scriptable Events/Double Scriptable Event",
        order = 4
    )]
    public class DoubleScriptableEvent : BaseScriptableEvent<double>
    {
    }
}
