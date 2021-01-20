namespace GameEvents
{
    public interface IGameEventListener<in TArg>
    {
        /// <summary>
        /// Handle raised game event by accepting its argument.
        /// </summary>
        void OnRaised(TArg arg);
    }
}
