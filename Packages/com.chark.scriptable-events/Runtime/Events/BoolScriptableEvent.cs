using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "BoolScriptableEvent",
        menuName = "Scriptable Events/Bool Scriptable Event",
        order = ScriptableEventConstants.PrimitiveScriptableEventOrder + 0
    )]
    public class BoolScriptableEvent : BaseScriptableEvent<bool>
    {
    }
}
