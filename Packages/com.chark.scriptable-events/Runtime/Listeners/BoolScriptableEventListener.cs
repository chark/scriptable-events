using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Bool Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 0
    )]
    public class BoolScriptableEventListener : BaseScriptableEventListener<bool>
    {
    }
}
