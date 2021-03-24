using UnityEngine;

namespace ScriptableEvents.Collision
{
    [AddComponentMenu("Scriptable Events/Listeners/Collision Scriptable Event Listener", 11)]
    public class CollisionScriptableEventListener
        : BaseScriptableEventListener<
            CollisionScriptableEvent,
            CollisionUnityEvent,
            UnityEngine.Collision
        >
    {
    }
}
