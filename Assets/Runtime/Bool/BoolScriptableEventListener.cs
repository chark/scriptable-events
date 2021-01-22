using UnityEngine;

namespace ScriptableEvents.Bool
{
    [AddComponentMenu("Scriptable Events/Bool Scriptable Event Listener")]
    public class BoolScriptableEventListener
        : BaseScriptableEventListener<BoolScriptableEvent, BoolUnityEvent, bool>
    {
    }
}
