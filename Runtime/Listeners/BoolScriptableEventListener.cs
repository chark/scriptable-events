using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Bool Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 0
    )]
    public sealed class BoolScriptableEventListener : ScriptableEventListener<bool>
    {
    }
}
