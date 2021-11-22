using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "BoolScriptableEvent",
        menuName = ScriptableEventConstants.MenuNamePrefix + "/Bool Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 0
    )]
    public class BoolScriptableEvent : BaseScriptableEvent<bool>
    {
    }
}
