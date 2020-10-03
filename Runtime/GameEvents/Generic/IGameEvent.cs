namespace GameEvents.Generic
{
    public interface IGameEvent
    {
        /// <summary>
        ///     Raise this event.
        /// </summary>
        void RaiseGameEvent();

        // TODO UNUSED
        /// <summary>
        ///     Register a listener to this event.
        /// </summary>
        void RegisterListener(IGameEventListener listener);

        // TODO UNUSED
        /// <summary>
        ///     Unregister a listener from this event.
        /// </summary>
        void UnregisterListener(IGameEventListener listener);
    }
}
