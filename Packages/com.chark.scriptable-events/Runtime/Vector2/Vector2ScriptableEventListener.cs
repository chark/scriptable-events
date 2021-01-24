using UnityEngine;

namespace ScriptableEvents.Vector2
{
    [AddComponentMenu("Scriptable Events/Vector2 Scriptable Event Listener", 7)]
    public class Vector2ScriptableEventListener
        : BaseScriptableEventListener<
            Vector2ScriptableEvent,
            Vector2UnityEvent,
            UnityEngine.Vector2
        >
    {
    }
}
