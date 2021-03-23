using UnityEngine;

namespace ScriptableEvents.String
{
    [AddComponentMenu("Scriptable Events/String Scriptable Event Listener", 4)]
    public class StringScriptableEventListener
        : BaseScriptableEventListener<StringScriptableEvent, StringUnityEvent, string>
    {
    }
}
