using CHARK.ScriptableEvents.Events;
using UnityEngine;

namespace CHARK.ScriptableEvents.Listeners
{
    [AddComponentMenu(
        ScriptableEventConstants.MenuNameBase + "/Simple Scriptable Event Listener",
        ScriptableEventConstants.MenuOrderSimpleEvent + 0
    )]
    public sealed class SimpleScriptableEventListener : ScriptableEventListener<SimpleArg>
    {
    }
}
