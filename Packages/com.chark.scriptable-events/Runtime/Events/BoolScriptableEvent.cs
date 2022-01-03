using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "BoolScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Bool Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 0
    )]
    public class BoolScriptableEvent : BaseScriptableEvent<bool>
    {
    }
}
