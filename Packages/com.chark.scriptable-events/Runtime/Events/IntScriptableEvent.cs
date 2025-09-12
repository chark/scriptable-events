using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "IntScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Int Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent
    )]
    public sealed class IntScriptableEvent : ScriptableEvent<int>
    {
    }
}
