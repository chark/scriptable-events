using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Float Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 3
    )]
    public sealed class FloatScriptableEventListener : ScriptableEventListener<float>
    {
    }
}
