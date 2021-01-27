using UnityEngine;

namespace ScriptableEvents.Samples.CustomEvents
{
    [AddComponentMenu("Custom Scriptable Events/Material Data Event Listener")]
    public class MaterialDataScriptableEventListener
        : BaseScriptableEventListener<
            MaterialDataScriptableEvent,
            MaterialDataUnityEvent,
            MaterialData
        >
    {
    }
}
