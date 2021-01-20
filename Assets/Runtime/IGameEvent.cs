using System.Collections.Generic;

namespace GameEvents
{
    public interface IGameEvent<TArg>
    {
        /// <return>
        /// Registered listeners.
        /// </return>
        ICollection<IGameEventListener<TArg>> Listeners { get; }

        /// <summary>
        /// Raise this game event with an argument.
        /// </summary>
        void Raise(TArg arg);

        /// <summary>
        /// Add a listener to this game event.
        /// </summary>
        void Add(IGameEventListener<TArg> listener);

        /// <summary>
        /// Remove a listener from this game event.
        /// </summary>
        void Remove(IGameEventListener<TArg> listener);
    }
}
