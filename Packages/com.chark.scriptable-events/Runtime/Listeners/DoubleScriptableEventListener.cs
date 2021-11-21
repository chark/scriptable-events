using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Double Scriptable Event Listener",
        ScriptableEventConstants.PrimitiveScriptableEventOrder + 4
    )]
    public class DoubleScriptableEventListener : BaseScriptableEventListener<double>
    {
    }
}
