namespace ScriptableEvents
{
    public interface IScriptableEvent<TArg>
    {
        /// <summary>
        /// Raise this event with an argument.
        /// </summary>
        void Raise(TArg value);

        /// <summary>
        /// Add a listener to this event.
        /// </summary>
        void AddListener(IScriptableEventListener<TArg> listener);

        /// <summary>
        /// Remove a listener from this event.
        /// </summary>
        void RemoveListener(IScriptableEventListener<TArg> listener);

        /// <summary>
        /// Remove all listeners from this event.
        /// </summary>
        void RemoveListeners();
    }
}
