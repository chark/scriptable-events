using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "StringScriptableEvent",
        menuName = "Scriptable Events/String Scriptable Event",
        order = ScriptableEventConstants.PrimitiveScriptableEventOrder + 5
    )]
    public class StringScriptableEvent : BaseScriptableEvent<string>
    {
    }
}
