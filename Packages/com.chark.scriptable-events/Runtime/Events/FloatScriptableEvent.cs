using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "FloatScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Float Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 5
    )]
    public sealed class FloatScriptableEvent : ScriptableEvent<float>
    {
    }
}
