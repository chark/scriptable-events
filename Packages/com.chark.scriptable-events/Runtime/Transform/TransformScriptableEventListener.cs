using UnityEngine;

namespace ScriptableEvents.Transform
{
    [AddComponentMenu("Scriptable Events/Listeners/Transform Scriptable Event Listener", 7)]
    public class TransformScriptableEventListener
        : BaseScriptableEventListener<
            TransformScriptableEvent,
            TransformUnityEvent,
            UnityEngine.Transform
        >
    {
    }
}
