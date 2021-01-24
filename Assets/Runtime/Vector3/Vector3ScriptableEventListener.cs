using UnityEngine;

namespace ScriptableEvents.Vector3
{
    [AddComponentMenu("Scriptable Events/Vector3 Scriptable Event Listener", 8)]
    public class Vector3ScriptableEventListener
        : BaseScriptableEventListener<
            Vector3ScriptableEvent,
            Vector3UnityEvent,
            UnityEngine.Vector3
        >
    {
    }
}
