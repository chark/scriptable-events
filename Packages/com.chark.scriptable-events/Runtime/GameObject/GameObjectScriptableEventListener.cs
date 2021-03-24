using UnityEngine;

namespace ScriptableEvents.GameObject
{
    [AddComponentMenu("Scriptable Events/Listeners/Game Object Scriptable Event Listener", 8)]
    public class GameObjectScriptableEventListener
        : BaseScriptableEventListener<
            GameObjectScriptableEvent,
            GameObjectUnityEvent,
            UnityEngine.GameObject
        >
    {
    }
}
