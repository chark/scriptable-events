using UnityEngine;

namespace ScriptableEvents.Transform
{
    [AddComponentMenu("Scriptable Events/Transform Scriptable Event Listener")]
    public class TransformScriptableEventListener
        : BaseScriptableEventListener<
            TransformScriptableEvent,
            TransformUnityEvent,
            UnityEngine.Transform
        >
    {
    }
}
