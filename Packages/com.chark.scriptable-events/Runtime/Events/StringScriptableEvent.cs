using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "StringScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/String Scriptable Event",
        order = ScriptableEventConstants.MenuOrderPrimitiveEvent + 5
    )]
    public sealed class StringScriptableEvent : ScriptableEvent<string>
    {
    }
}
