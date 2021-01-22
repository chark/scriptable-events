using UnityEngine;

namespace ScriptableEvents.GameObject
{
    [AddComponentMenu("Scriptable Events/Game Object Scriptable Event Listener")]
    public class GameObjectScriptableEventListener
        : BaseScriptableEventListener<
            GameObjectScriptableEvent,
            GameObjectUnityEvent,
            UnityEngine.GameObject
        >
    {
    }
}
