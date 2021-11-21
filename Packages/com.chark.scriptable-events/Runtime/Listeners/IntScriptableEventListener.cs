using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Int Scriptable Event Listener",
        ScriptableEventConstants.PrimitiveScriptableEventOrder + 1
    )]
    public class IntScriptableEventListener : BaseScriptableEventListener<int>
    {
    }
}
