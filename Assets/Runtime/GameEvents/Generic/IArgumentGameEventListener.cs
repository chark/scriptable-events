namespace GameEvents.Generic
{
    public interface IArgumentGameEventListener<in TArgument>
    {
        /// <summary>
        ///     Trigger this listener with an argument.
        /// </summary>
        void OnGameEvent(TArgument argument);
    }
}
