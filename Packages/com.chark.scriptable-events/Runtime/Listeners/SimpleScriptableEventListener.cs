using CHARK.ScriptableEvents.Events;
using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Simple Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderSimpleEvent
    )]
    public sealed class SimpleScriptableEventListener : ScriptableEventListener<SimpleArg>
    {
    }
}
