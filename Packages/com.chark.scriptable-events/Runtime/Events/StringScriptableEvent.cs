using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "StringScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/String Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent
    )]
    public sealed class StringScriptableEvent : ScriptableEvent<string>
    {
    }
}
