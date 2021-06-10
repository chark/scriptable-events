using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using ScriptableEvents.Events;
using UnityEngine;

namespace ScriptableEvents.Tests
{
    [TestFixture]
    public class SimpleScriptableEventTest
    {
        // Requires additional test case as SimpleScriptableEvent introduces a new method.
        [Test]
        public void ShouldRaiseEventWithoutArgument()
        {
            var capturedArgs = new List<SimpleArg>();
            var mockScriptableEventListener = new MockScriptableEventListener<SimpleArg>
            {
                Action = capturedArgs.Add
            };

            var simpleScriptableEvent = ScriptableObject.CreateInstance<SimpleScriptableEvent>();
            simpleScriptableEvent.AddListener(mockScriptableEventListener);

            simpleScriptableEvent.Raise();

            Assert.AreEqual(1, capturedArgs.Count);
            Assert.AreEqual(SimpleArg.Instance, capturedArgs.First());
        }
    }
}
