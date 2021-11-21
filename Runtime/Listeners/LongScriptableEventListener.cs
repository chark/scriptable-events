using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Long Scriptable Event Listener",
        ScriptableEventConstants.PrimitiveScriptableEventOrder + 2
    )]
    public class LongScriptableEventListener : BaseScriptableEventListener<long>
    {
    }
}
