namespace GameEvents.Generic
{
    public interface IGameEvent
    {
        /// <summary>
        ///     Raise this event.
        /// </summary>
        void RaiseGameEvent();

        /// <summary>
        ///     Register a listener to this event.
        /// </summary>
        void RegisterListener(IGameEventListener listener);

        /// <summary>
        ///     Unregister a listener from this event.
        /// </summary>
        void UnregisterListener(IGameEventListener listener);
    }
}
