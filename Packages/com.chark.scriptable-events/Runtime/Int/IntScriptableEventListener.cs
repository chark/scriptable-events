using UnityEngine;

namespace ScriptableEvents.Int
{
    [AddComponentMenu("Scriptable Events/Int Scriptable Event Listener", 2)]
    public class IntScriptableEventListener
        : BaseScriptableEventListener<IntScriptableEvent, IntUnityEvent, int>
    {
    }
}
