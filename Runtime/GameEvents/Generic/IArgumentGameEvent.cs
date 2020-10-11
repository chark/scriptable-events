using System.Collections.Generic;

namespace GameEvents.Generic
{
    public interface IArgumentGameEvent<TArgument>
    {
        /// <summary>
        ///     Currently registered listeners.
        /// </summary>
        IEnumerable<IArgumentGameEventListener<TArgument>> Listeners { get; }

        /// <summary>
        ///     Raise this event with an argument.
        /// </summary>
        void RaiseGameEvent(TArgument argument);

        /// <summary>
        ///     Register a listener with an argument to this event.
        /// </summary>
        void RegisterListener(IArgumentGameEventListener<TArgument> listener);

        /// <summary>
        ///     Unregister a listener with an argument from this event.
        /// </summary>
        void UnregisterListener(IArgumentGameEventListener<TArgument> listener);
    }
}
