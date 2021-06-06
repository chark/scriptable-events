using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "BoolScriptableEvent",
        menuName = "Scriptable Events/Bool Scriptable Event",
        order = 1
    )]
    public class BoolScriptableEvent : BaseScriptableEvent<bool>
    {
    }
}
