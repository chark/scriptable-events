using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "IntScriptableEvent",
        menuName = "Scriptable Events/Int Scriptable Event",
        order = ScriptableEventConstants.PrimitiveScriptableEventOrder + 1
    )]
    public class IntScriptableEvent : BaseScriptableEvent<int>
    {
    }
}
