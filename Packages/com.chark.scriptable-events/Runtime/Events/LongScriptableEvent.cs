using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "LongScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Long Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 4
    )]
    public sealed class LongScriptableEvent : ScriptableEvent<long>
    {
    }
}
