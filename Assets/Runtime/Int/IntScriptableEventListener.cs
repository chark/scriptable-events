using UnityEngine;

namespace ScriptableEvents.Int
{
    [AddComponentMenu("Scriptable Events/Int Scriptable Event Listener")]
    public class IntScriptableEventListener
        : BaseScriptableEventListener<IntScriptableEvent, IntUnityEvent, int>
    {
    }
}
