using UnityEngine;

namespace ScriptableEvents.Events
{
    [CreateAssetMenu(
        fileName = "SimpleScriptableEvent",
        menuName = "Scriptable Events/Simple Scriptable Event",
        order = -100
    )]
    public class SimpleScriptableEvent : BaseScriptableEvent<SimpleArg>
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
