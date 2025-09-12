using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "LongScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Long Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent
    )]
    public sealed class LongScriptableEvent : ScriptableEvent<long>
    {
    }
}
