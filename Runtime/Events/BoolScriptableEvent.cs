using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "BoolScriptableEvent",
        menuName = "Scriptable Events/Bool Scriptable Event",
        order = 0
    )]
    public class BoolScriptableEvent : BaseScriptableEvent<bool>
    {
    }
}
