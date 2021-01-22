using UnityEngine;

namespace ScriptableEvents.Vector3
{
    [AddComponentMenu("Scriptable Events/Vector3 Scriptable Event Listener")]
    public class Vector3ScriptableEventListener
        : BaseScriptableEventListener<
            Vector3ScriptableEvent,
            VectorUnity3Event,
            UnityEngine.Vector3
        >
    {
    }
}
