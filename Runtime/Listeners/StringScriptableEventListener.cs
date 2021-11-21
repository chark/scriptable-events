using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/String Scriptable Event Listener",
        ScriptableEventConstants.PrimitiveScriptableEventOrder + 5
    )]
    public class StringScriptableEventListener : BaseScriptableEventListener<string>
    {
    }
}
