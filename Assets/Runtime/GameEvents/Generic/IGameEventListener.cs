namespace GameEvents.Generic
{
    public interface IGameEventListener
    {
        /// <summary>
        ///     Trigger this listener.
        /// </summary>
        void RaiseGameEvent();
    }
}
