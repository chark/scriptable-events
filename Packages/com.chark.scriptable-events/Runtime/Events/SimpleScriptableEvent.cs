using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "SimpleScriptableEvent",
        menuName = ScriptableEventConstants.MenuNameBase + "/Simple Scriptable Event",
        order = ScriptableEventConstants.MenuOrderSimpleEvent + 0
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
