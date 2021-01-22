namespace ScriptableEvents.Tests
{
    public class NoOpListener<TArg> : IScriptableEventListener<TArg>
    {
        public void OnRaised(TArg arg)
        {
        }
    }
}
