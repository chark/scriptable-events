using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Int Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 1
    )]
    public class IntScriptableEventListener : BaseScriptableEventListener<int>
    {
    }
}
