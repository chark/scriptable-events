using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Float Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 5
    )]
    public sealed class FloatScriptableEventListener : ScriptableEventListener<float>
    {
    }
}
