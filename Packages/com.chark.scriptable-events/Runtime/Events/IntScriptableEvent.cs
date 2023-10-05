using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "IntScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Int Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 1
    )]
    public sealed class IntScriptableEvent : ScriptableEvent<int>
    {
    }
}
