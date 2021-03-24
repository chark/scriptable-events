using UnityEngine;

namespace ScriptableEvents.String
{
    [AddComponentMenu("Scriptable Events/Listeners/String Scriptable Event Listener", 4)]
    public class StringScriptableEventListener
        : BaseScriptableEventListener<StringScriptableEvent, StringUnityEvent, string>
    {
    }
}
