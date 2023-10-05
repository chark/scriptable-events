using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "FloatScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Float Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 3
    )]
    public sealed class FloatScriptableEvent : ScriptableEvent<float>
    {
    }
}
