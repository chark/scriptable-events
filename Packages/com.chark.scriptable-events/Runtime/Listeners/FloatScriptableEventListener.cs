using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Float Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 3
    )]
    public class FloatScriptableEventListener : BaseScriptableEventListener<float>
    {
    }
}
