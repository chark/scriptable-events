using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;

namespace ScriptableEvents.Tests.Runtime
{
    [TestFixtureSource(typeof(ScriptableEventTestSource))]
    internal class ScriptableEventTest<
        TScriptableEvent,
        TScriptableEventListener,
        TArg
    >
        where TScriptableEvent : BaseScriptableEvent<TArg>
        where TScriptableEventListener : BaseScriptableEventListener<TArg>
    {
        #region Private Fields

        private readonly TArg arg;

        private List<TArg> capturedArgs;
        private TScriptableEvent scriptableEvent;
        private UnityEvent<TArg> unityEvent;
        private TScriptableEventListener scriptableEventListener;

        #endregion

        #region Public Methods

        public ScriptableEventTest(TArg arg)
        {
            this.arg = arg;
        }

        [SetUp]
        public void SetUp()
        {
            SetupRaisedArgs();
            SetupScriptableEvent();
            SetupUnityEvent();
            SetupScriptableEventListener();
        }

        [Test]
        public void ShouldRaiseEvent()
        {
            scriptableEvent.Raise(arg);

            Assert.AreEqual(1, capturedArgs.Count);
            Assert.AreEqual(arg, capturedArgs.First());
        }

        [Test]
        public void ShouldAddActionListenerAndRaiseEvent()
        {
            var capturedActionArgs = new List<TArg>();
            scriptableEvent.AddListener(capturedActionArgs.Add);

            scriptableEvent.Raise(arg);

            Assert.AreEqual(1, capturedArgs.Count);
            Assert.AreEqual(arg, capturedArgs.First());
        }

        [Test]
        public void ShouldRaiseEventAndContinueListenerChain()
        {
            LogAssert.ignoreFailingMessages = true;

            scriptableEvent.SetField("isSuppressExceptions", true);
            scriptableEvent.AddListener(new MockScriptableEventListener<TArg>
            {
                Action = capturedArg => throw new Exception()
            });

            scriptableEvent.Raise(arg);

            Assert.AreEqual(1, capturedArgs.Count);
        }

        [Test]
        public void ShouldRemoveListenerAndRaiseEvent()
        {
            scriptableEvent.RemoveListeners();

            scriptableEvent.AddListener(scriptableEventListener);
            scriptableEvent.RemoveListener(scriptableEventListener);
            scriptableEvent.Raise(arg);

            Assert.AreEqual(0, scriptableEvent.ListenerCount);
            Assert.AreEqual(0, capturedArgs.Count);
        }

        [Test]
        public void ShouldAddAndRemoveActionListenerAndRaiseEvent()
        {
            scriptableEvent.RemoveListeners();

            scriptableEvent.AddListener(capturedArgs.Add);
            scriptableEvent.RemoveListener(capturedArgs.Add);

            scriptableEvent.Raise(arg);

            Assert.AreEqual(0, scriptableEvent.ListenerCount);
            Assert.AreEqual(0, capturedArgs.Count);
        }

        [Test]
        public void ShouldRemoveListenersAndRaiseEvent()
        {
            scriptableEvent.RemoveListeners();
            scriptableEvent.Raise(arg);

            Assert.AreEqual(0, capturedArgs.Count);
        }

        #endregion

        #region Private Methods

        private void SetupRaisedArgs()
        {
            capturedArgs = new List<TArg>();
        }

        private void SetupScriptableEvent()
        {
            scriptableEvent = ScriptableObject.CreateInstance<TScriptableEvent>();
        }

        private void SetupUnityEvent()
        {
            unityEvent = new UnityEvent<TArg>();
            unityEvent.AddListener(capturedArgs.Add);
        }

        private void SetupScriptableEventListener()
        {
            var gameObject = new GameObject();
            gameObject.SetActive(false);

            scriptableEventListener = gameObject.AddComponent<TScriptableEventListener>();

            // Note: the type for scriptableEvents is NOT TScriptableEvent, it is BaseScriptableEvent<TArg>
            // If treated as TScriptableEvent, casting fails.
            scriptableEventListener.AddToListField<BaseScriptableEvent<TArg>>("scriptableEvents", scriptableEvent);
            scriptableEventListener.SetField("onRaised", unityEvent);

            // Add listener by triggering OnEnabled.
            gameObject.SetActive(true);
        }

        #endregion
    }
}
