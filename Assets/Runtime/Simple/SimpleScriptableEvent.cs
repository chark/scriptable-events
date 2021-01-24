using UnityEngine;

namespace ScriptableEvents.Simple
{
    [CreateAssetMenu(
        fileName = "SimpleScriptableEvent",
        menuName = "Scriptable Events/Simple Scriptable Event",
        order = -10
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
