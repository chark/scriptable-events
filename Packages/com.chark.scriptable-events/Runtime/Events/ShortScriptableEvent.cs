using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "ShortScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Short Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 2
    )]
    public sealed class ShortScriptableEvent : ScriptableEvent<short>
    {
    }
}
