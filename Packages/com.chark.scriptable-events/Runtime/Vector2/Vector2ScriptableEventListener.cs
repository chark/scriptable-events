using UnityEngine;

namespace ScriptableEvents.Vector2
{
    [AddComponentMenu("Scriptable Events/Listeners/Vector2 Scriptable Event Listener", 5)]
    public class Vector2ScriptableEventListener
        : BaseScriptableEventListener<
            Vector2ScriptableEvent,
            Vector2UnityEvent,
            UnityEngine.Vector2
        >
    {
    }
}
