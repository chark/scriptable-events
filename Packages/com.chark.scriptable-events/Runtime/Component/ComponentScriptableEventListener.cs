using UnityEngine;

namespace ScriptableEvents.Component
{
    [AddComponentMenu("Scriptable Events/Component Scriptable Event Listener", 9)]
    public class ComponentScriptableEventListener
        : BaseScriptableEventListener<
            ComponentScriptableEvent,
            ComponentUnityEvent,
            UnityEngine.Component
        >
    {
    }
}
