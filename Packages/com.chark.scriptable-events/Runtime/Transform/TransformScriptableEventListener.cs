using UnityEngine;

namespace ScriptableEvents.Transform
{
    [AddComponentMenu("Scriptable Events/Transform Scriptable Event Listener", 7)]
    public class TransformScriptableEventListener
        : BaseScriptableEventListener<
            TransformScriptableEvent,
            TransformUnityEvent,
            UnityEngine.Transform
        >
    {
    }
}
