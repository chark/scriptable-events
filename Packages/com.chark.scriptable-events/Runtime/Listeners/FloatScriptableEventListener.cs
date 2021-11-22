using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNamePrefix + "/Float Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 3
    )]
    public class FloatScriptableEventListener : BaseScriptableEventListener<float>
    {
    }
}
