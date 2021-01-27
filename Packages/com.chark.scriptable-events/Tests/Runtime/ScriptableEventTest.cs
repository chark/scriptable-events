using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TestTools;

namespace ScriptableEvents.Tests
{
    [TestFixtureSource(typeof(ScriptableEventTestSource))]
    public class ScriptableEventTest<
        TScriptableEvent,
        TScriptableEventListener,
        TUnityEvent,
        TArg
    >
        where TScriptableEvent : ScriptableObject, IScriptableEvent<TArg>
        where TScriptableEventListener : Component, IScriptableEventListener<TArg>
        where TUnityEvent : UnityEvent<TArg>, new()
    {
        #region Fields

        private readonly TArg arg;

        private List<TArg> capturedArgs;
        private TScriptableEvent scriptableEvent;
        private TUnityEvent unityEvent;
        private TScriptableEventListener scriptableEventListener;

        #endregion

        #region Methods

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
        public void ShouldGetListeners()
        {
            var listeners = scriptableEvent.Listeners;

            // By default one listener is added in this test.
            Assert.AreEqual(1, listeners.Count);
            Assert.AreEqual(scriptableEventListener, listeners.First());
        }

        [Test]
        public void ShouldRaiseEvent()
        {
            scriptableEvent.Raise(arg);

            Assert.AreEqual(1, capturedArgs.Count);
            Assert.AreEqual(arg, capturedArgs.First());
        }

        [Test]
        public void ShouldRaiseEventAndContinueListenerChain()
        {
            LogAssert.ignoreFailingMessages = true;

            scriptableEvent.SetField("suppressExceptions", true);
            scriptableEvent.Add(new MockScriptableEventListener<TArg>
            {
                Action = capturedArg => throw new Exception()
            });

            scriptableEvent.Raise(arg);

            Assert.AreEqual(1, capturedArgs.Count);
        }

        [Test]
        public void ShouldAddListenerTwiceAndRaiseEventOnce()
        {
            scriptableEvent.Add(scriptableEventListener);
            scriptableEvent.Raise(arg);

            Assert.AreEqual(1, capturedArgs.Count);
        }

        [Test]
        public void ShouldRemoveListenerAndRaiseEvent()
        {
            scriptableEvent.Remove(scriptableEventListener);
            scriptableEvent.Raise(arg);

            Assert.AreEqual(0, capturedArgs.Count);
        }

        [Test]
        public void ShouldClearAndRaiseEvent()
        {
            scriptableEvent.Clear();
            scriptableEvent.Raise(arg);

            Assert.AreEqual(0, capturedArgs.Count);
        }

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
            unityEvent = new TUnityEvent();
            unityEvent.AddListener(capturedArgs.Add);
        }

        private void SetupScriptableEventListener()
        {
            var gameObject = new UnityEngine.GameObject();
            gameObject.SetActive(false);

            scriptableEventListener = gameObject.AddComponent<TScriptableEventListener>();
            scriptableEventListener.SetField("scriptableEvent", scriptableEvent);
            scriptableEventListener.SetField("onRaised", unityEvent);

            // Add listener by triggering OnEnabled.
            gameObject.SetActive(true);
        }

        #endregion
    }
}
