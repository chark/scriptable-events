using UnityEngine;

namespace CHARK.ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "SimpleScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Simple Scriptable Event",
        order = ScriptableEventConstants.MenuOrderSimpleEvent
    )]
    public sealed class SimpleScriptableEvent : ScriptableEvent<SimpleArg>
    {
        /// <summary>
        /// Raise this event without an argument.
        /// </summary>
        public void Raise()
        {
            Raise(SimpleArg.Instance);
        }
    }
}
