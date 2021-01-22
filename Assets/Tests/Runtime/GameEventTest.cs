using System.Linq;
using ScriptableEvents.Bool;
using ScriptableEvents.Float;
using ScriptableEvents.GameObject;
using ScriptableEvents.Int;
using ScriptableEvents.Simple;
using ScriptableEvents.String;
using ScriptableEvents.Transform;
using ScriptableEvents.Vector2;
using ScriptableEvents.Vector3;
using NUnit.Framework;
using UnityEngine;
using Assert = UnityEngine.Assertions.Assert;

// todo: look over tests, use parametrized
namespace ScriptableEvents.Tests
{
    public class ScriptableEventTest
    {
        [Test]
        public void ShouldRaiseBoolScriptableEvent()
        {
            var tester = new ScriptableEventTester<
                BoolScriptableEventListener,
                BoolScriptableEvent,
                BoolUnityEvent,
                bool
            >();

            tester.SetActive(true);
            tester.RaiseScriptableEvent(true);

            Assert.AreEqual(true, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseScriptableEvent(true);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterBoolScriptableEventListener()
        {
            var ScriptableEvent = ScriptableObject.CreateInstance<BoolScriptableEvent>();
            var listener = new NoOpListener<bool>();

            ScriptableEvent.Add(listener);
            Assert.AreEqual(1, ScriptableEvent.Listeners.Count());

            ScriptableEvent.Remove(listener);
            Assert.AreEqual(0, ScriptableEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseFloatScriptableEvent()
        {
            var tester = new ScriptableEventTester<
                FloatScriptableEventListener,
                FloatScriptableEvent,
                FloatUnityEvent,
                float
            >();

            tester.SetActive(true);
            tester.RaiseScriptableEvent(10f);

            Assert.AreEqual(10f, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseScriptableEvent(10f);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterFloatScriptableEventListener()
        {
            var ScriptableEvent = ScriptableObject.CreateInstance<FloatScriptableEvent>();
            var listener = new NoOpListener<float>();

            ScriptableEvent.Add(listener);
            Assert.AreEqual(1, ScriptableEvent.Listeners.Count());

            ScriptableEvent.Remove(listener);
            Assert.AreEqual(0, ScriptableEvent.Listeners.Count());
        }

        // [Test]
        // public void ShouldRaiseScriptableEventEvent()
        // {
        //     // Given.
        //     var gameObject = new UnityEngine.GameObject();
        //     gameObject.SetActive(false);
        //
        //     var listener = gameObject.AddComponent<SimpleScriptableEventListener>();
        //
        //     listener.OnScriptableEvent = new UnityEvent();
        //     listener.ScriptableEvent = ScriptableObject.CreateInstance<SimpleScriptableEvent>();
        //
        //     var count = new int[1];
        //     listener.OnScriptableEvent.AddListener(() => count[0]++);
        //
        //     // Then.
        //     gameObject.SetActive(true);
        //     listener.ScriptableEvent.RaiseScriptableEvent();
        //
        //     Assert.AreEqual(1, count[0]);
        //     count[0] = 0;
        //
        //     gameObject.SetActive(false);
        //     listener.ScriptableEvent.RaiseScriptableEvent();
        //
        //     Assert.AreEqual(0, count[0]);
        // }
        //
        //
        // [Test]
        // public void ShouldNotBreakChainWhenExceptionIsThrown()
        // {
        //     // Given.
        //     var gameObject = new UnityEngine.GameObject();
        //     gameObject.SetActive(false);
        //
        //     var listenerWithError = gameObject.AddComponent<SimpleScriptableEventListener>();
        //     var listener = gameObject.AddComponent<SimpleScriptableEventListener>();
        //
        //     listenerWithError.OnScriptableEvent = new UnityEvent();
        //     listenerWithError.ScriptableEvent = ScriptableObject.CreateInstance<SimpleScriptableEvent>();
        //
        //     listener.OnScriptableEvent = new UnityEvent();
        //     listener.ScriptableEvent = listenerWithError.ScriptableEvent;
        //
        //     var count = new int[1];
        //     listenerWithError.OnScriptableEvent.AddListener(() => throw new NullReferenceException());
        //     listener.OnScriptableEvent.AddListener(() => count[0]++);
        //
        //     // Then.
        //     gameObject.SetActive(true);
        //     listener.ScriptableEvent.RaiseScriptableEvent();
        //
        //     Assert.AreEqual(1, count[0]);
        //     count[0] = 0;
        //
        //     gameObject.SetActive(false);
        //     listener.ScriptableEvent.RaiseScriptableEvent();
        //
        //     Assert.AreEqual(0, count[0]);
        // }

        [Test]
        public void ShouldRegisterAndUnregisterGameObjectScriptableEventListener()
        {
            var ScriptableEvent = ScriptableObject.CreateInstance<GameObjectScriptableEvent>();
            var listener = new NoOpListener<UnityEngine.GameObject>();

            ScriptableEvent.Add(listener);
            Assert.AreEqual(1, ScriptableEvent.Listeners.Count());

            ScriptableEvent.Remove(listener);
            Assert.AreEqual(0, ScriptableEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseGameObjectScriptableEventListener()
        {
            var tester = new ScriptableEventTester<
                GameObjectScriptableEventListener,
                GameObjectScriptableEvent,
                GameObjectUnityEvent,
                UnityEngine.GameObject
            >();

            tester.SetActive(true);

            var gameObject = new UnityEngine.GameObject();
            tester.RaiseScriptableEvent(gameObject);

            Assert.AreEqual(gameObject, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseScriptableEvent(gameObject);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterScriptableEventListener()
        {
            var ScriptableEvent = ScriptableObject.CreateInstance<SimpleScriptableEvent>();
            var listener = new NoOpListener<SimpleArg>();

            ScriptableEvent.Add(listener);
            Assert.AreEqual(1, ScriptableEvent.Listeners.Count());

            ScriptableEvent.Remove(listener);
            Assert.AreEqual(0, ScriptableEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseIntScriptableEventListener()
        {
            var tester = new ScriptableEventTester<
                IntScriptableEventListener,
                IntScriptableEvent,
                IntUnityEvent,
                int
            >();

            tester.SetActive(true);
            tester.RaiseScriptableEvent(10);

            Assert.AreEqual(10, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseScriptableEvent(10);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterIntScriptableEventListener()
        {
            var ScriptableEvent = ScriptableObject.CreateInstance<IntScriptableEvent>();
            var listener = new NoOpListener<int>();

            ScriptableEvent.Add(listener);
            Assert.AreEqual(1, ScriptableEvent.Listeners.Count());

            ScriptableEvent.Remove(listener);
            Assert.AreEqual(0, ScriptableEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseStringScriptableEventListener()
        {
            var tester = new ScriptableEventTester<
                StringScriptableEventListener,
                StringScriptableEvent,
                StringUnityEvent,
                string
            >();

            tester.SetActive(true);
            tester.RaiseScriptableEvent("foo");

            Assert.AreEqual("foo", tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseScriptableEvent("foo");

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterStringScriptableEventListener()
        {
            var ScriptableEvent = ScriptableObject.CreateInstance<StringScriptableEvent>();
            var listener = new NoOpListener<string>();

            ScriptableEvent.Add(listener);
            Assert.AreEqual(1, ScriptableEvent.Listeners.Count());

            ScriptableEvent.Remove(listener);
            Assert.AreEqual(0, ScriptableEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseTransformScriptableEventListener()
        {
            var tester = new ScriptableEventTester<
                TransformScriptableEventListener,
                TransformScriptableEvent,
                TransformUnityEvent,
                UnityEngine.Transform
            >();

            tester.SetActive(true);

            var gameObject = new UnityEngine.GameObject();
            tester.RaiseScriptableEvent(gameObject.transform);

            Assert.AreEqual(gameObject.transform, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseScriptableEvent(gameObject.transform);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterTransformScriptableEventListener()
        {
            var ScriptableEvent = ScriptableObject.CreateInstance<TransformScriptableEvent>();
            var listener = new NoOpListener<UnityEngine.Transform>();

            ScriptableEvent.Add(listener);
            Assert.AreEqual(1, ScriptableEvent.Listeners.Count());

            ScriptableEvent.Remove(listener);
            Assert.AreEqual(0, ScriptableEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseVector2EventListener()
        {
            var tester = new ScriptableEventTester<
                Vector2ScriptableEventListener,
                Vector2ScriptableEvent,
                Vector2UnityEvent,
                UnityEngine.Vector2
            >();

            tester.SetActive(true);
            tester.RaiseScriptableEvent(UnityEngine.Vector2.one);

            Assert.AreEqual(UnityEngine.Vector2.one, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseScriptableEvent(UnityEngine.Vector2.one);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterVector2ScriptableEventListener()
        {
            var ScriptableEvent = ScriptableObject.CreateInstance<Vector2ScriptableEvent>();
            var listener = new NoOpListener<UnityEngine.Vector2>();

            ScriptableEvent.Add(listener);
            Assert.AreEqual(1, ScriptableEvent.Listeners.Count());

            ScriptableEvent.Remove(listener);
            Assert.AreEqual(0, ScriptableEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseVector3EventListener()
        {
            var tester = new ScriptableEventTester<
                Vector3ScriptableEventListener,
                Vector3ScriptableEvent,
                VectorUnity3Event,
                UnityEngine.Vector3
            >();

            tester.SetActive(true);
            tester.RaiseScriptableEvent(UnityEngine.Vector3.one);

            Assert.AreEqual(UnityEngine.Vector3.one, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseScriptableEvent(UnityEngine.Vector3.one);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterVector3ScriptableEventListener()
        {
            var ScriptableEvent = ScriptableObject.CreateInstance<Vector3ScriptableEvent>();
            var listener = new NoOpListener<UnityEngine.Vector3>();

            ScriptableEvent.Add(listener);
            Assert.AreEqual(1, ScriptableEvent.Listeners.Count());

            ScriptableEvent.Remove(listener);
            Assert.AreEqual(0, ScriptableEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRegisterAndUnregisterScriptableEventMultipleListeners()
        {
            var ScriptableEvent = ScriptableObject.CreateInstance<Vector3ScriptableEvent>();
            var firstListener = new NoOpListener<UnityEngine.Vector3>();
            var secondListener = new NoOpListener<UnityEngine.Vector3>();

            ScriptableEvent.Add(firstListener);
            ScriptableEvent.Add(secondListener);
            Assert.AreEqual(2, ScriptableEvent.Listeners.Count());

            ScriptableEvent.Remove(firstListener);
            ScriptableEvent.Remove(secondListener);
            Assert.AreEqual(0, ScriptableEvent.Listeners.Count());
        }
    }
}
