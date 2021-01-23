using UnityEngine;

namespace ScriptableEvents.Simple
{
    [AddComponentMenu("Scriptable Events/Simple Scriptable Event Listener")]
    public class SimpleScriptableEventListener
        : BaseScriptableEventListener<SimpleScriptableEvent, SimpleUnityEvent, SimpleArg>
    {
    }
}
