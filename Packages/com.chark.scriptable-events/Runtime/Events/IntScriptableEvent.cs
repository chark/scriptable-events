using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "IntScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Int Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 3
    )]
    public sealed class IntScriptableEvent : ScriptableEvent<int>
    {
    }
}
