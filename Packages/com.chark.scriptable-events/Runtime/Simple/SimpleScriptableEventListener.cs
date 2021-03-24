using UnityEngine;

namespace ScriptableEvents.Simple
{
    [AddComponentMenu("Scriptable Events/Listeners/Simple Scriptable Event Listener", -10)]
    public class SimpleScriptableEventListener
        : BaseScriptableEventListener<SimpleScriptableEvent, SimpleUnityEvent, SimpleArg>
    {
    }
}
