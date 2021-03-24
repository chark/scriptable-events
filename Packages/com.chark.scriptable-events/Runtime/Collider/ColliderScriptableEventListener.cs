using UnityEngine;

namespace ScriptableEvents.Collider
{
    [AddComponentMenu("Scriptable Events/Listeners/Collider Scriptable Event Listener", 10)]
    public class ColliderScriptableEventListener
        : BaseScriptableEventListener<
            ColliderScriptableEvent,
            ColliderUnityEvent,
            UnityEngine.Collider
        >
    {
    }
}
