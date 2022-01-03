using ScriptableEvents.Events;
using UnityEngine;

namespace ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Simple Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderSimpleEvent + 0
    )]
    public class SimpleScriptableEventListener : BaseScriptableEventListener<SimpleArg>
    {
    }
}
