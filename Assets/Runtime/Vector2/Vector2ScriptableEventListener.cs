using UnityEngine;

namespace ScriptableEvents.Vector2
{
    [AddComponentMenu("Scriptable Events/Vector2 Scriptable Event Listener")]
    public class Vector2ScriptableEventListener
        : BaseScriptableEventListener<
            Vector2ScriptableEvent,
            Vector2UnityEvent,
            UnityEngine.Vector2
        >
    {
    }
}
