using UnityEngine;

namespace ScriptableEvents.Bool
{
    [AddComponentMenu("Scriptable Events/Bool Scriptable Event Listener", 1)]
    public class BoolScriptableEventListener
        : BaseScriptableEventListener<BoolScriptableEvent, BoolUnityEvent, bool>
    {
    }
}
