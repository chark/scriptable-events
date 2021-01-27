using System;

namespace ScriptableEvents.Tests
{
    public class MockScriptableEventListener<TArg> : IScriptableEventListener<TArg>
    {
        public Action<TArg> Action { get; set; }

        public void OnRaised(TArg arg)
        {
            Action?.Invoke(arg);
        }
    }
}
