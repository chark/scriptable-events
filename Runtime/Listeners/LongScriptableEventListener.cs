using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNamePrefix + "/Long Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderPrimitiveEvent + 2
    )]
    public class LongScriptableEventListener : BaseScriptableEventListener<long>
    {
    }
}
