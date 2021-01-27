using UnityEngine;

namespace ScriptableEvents.String
{
    [AddComponentMenu("Scriptable Events/String Scriptable Event Listener", 5)]
    public class StringScriptableEventListener
        : BaseScriptableEventListener<StringScriptableEvent, StringUnityEvent, string>
    {
    }
}
