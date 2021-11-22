using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNamePrefix + "/Bool Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 0
    )]
    public class BoolScriptableEventListener : BaseScriptableEventListener<bool>
    {
    }
}
