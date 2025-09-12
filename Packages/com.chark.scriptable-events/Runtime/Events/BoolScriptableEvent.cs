using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "BoolScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Bool Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent
    )]
    public sealed class BoolScriptableEvent : ScriptableEvent<bool>
    {
    }
}
