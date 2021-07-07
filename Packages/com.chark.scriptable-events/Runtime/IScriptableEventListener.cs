namespace ScriptableEvents
{
    public interface IScriptableEventListener<in TArg>
    {
        /// <summary>
        /// Handle raised event by accepting its argument.
        /// </summary>
        void OnRaised(TArg value);
    }
}
