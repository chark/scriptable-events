using System;

namespace ScriptableEvents.Tests
{
    internal class MockScriptableEventListener<TArg> : IScriptableEventListener<TArg>
    {
        internal Action<TArg> Action { get; set; }

        public void OnRaised(TArg value)
        {
            Action?.Invoke(value);
        }
    }
}
