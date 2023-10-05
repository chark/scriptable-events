using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "LongScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Long Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 2
    )]
    public sealed class LongScriptableEvent : ScriptableEvent<long>
    {
    }
}
