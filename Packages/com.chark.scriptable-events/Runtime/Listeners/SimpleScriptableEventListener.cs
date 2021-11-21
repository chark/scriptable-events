using ScriptableEvents.Events;
using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        "Scriptable Events/Simple Scriptable Event Listener",
        ScriptableEventConstants.SimpleScriptableEventOrder + 0
    )]
    public class SimpleScriptableEventListener : BaseScriptableEventListener<SimpleArg>
    {
    }
}
