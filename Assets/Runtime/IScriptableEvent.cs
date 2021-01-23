using System.Collections.Generic;

namespace ScriptableEvents
{
    public interface IScriptableEvent<TArg>
    {
        /// <summary>
        /// Raise this event with an argument.
        /// </summary>
        void Raise(TArg arg);

        /// <summary>
        /// Add a listener to this event.
        /// </summary>
        void Add(IScriptableEventListener<TArg> listener);

        /// <summary>
        /// Remove a listener from this event.
        /// </summary>
        void Remove(IScriptableEventListener<TArg> listener);

        /// <summary>
        /// Remove all listeners from this event.
        /// </summary>
        void Clear();
    }
}
