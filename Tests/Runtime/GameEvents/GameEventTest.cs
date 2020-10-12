using System.Linq;
using GameEvents.Bool;
using GameEvents.Float;
using GameEvents.Game;
using GameEvents.GameObject;
using GameEvents.Int;
using GameEvents.String;
using GameEvents.Transform;
using GameEvents.Vector2;
using GameEvents.Vector3;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.Events;
using Assert = UnityEngine.Assertions.Assert;

namespace GameEvents
{
    public class GameEventTest
    {
        [Test]
        public void ShouldRaiseBoolGameEvent()
        {
            var tester = new GameEventTester<
                BoolGameEventListener,
                BoolGameEvent,
                BoolEvent,
                bool
            >();

            tester.SetActive(true);
            tester.RaiseGameEvent(true);

            Assert.AreEqual(true, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(true);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterBoolGameEvent()
        {
            var gameEvent = ScriptableObject.CreateInstance<BoolGameEvent>();
            var listener = new NoOpArgumentListener<bool>();

            gameEvent.RegisterListener(listener);
            Assert.AreEqual(1, gameEvent.Listeners.Count());

            gameEvent.UnregisterListener(listener);
            Assert.AreEqual(0, gameEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseFloatGameEvent()
        {
            var tester = new GameEventTester<
                FloatGameEventListener,
                FloatGameEvent,
                FloatEvent,
                float
            >();

            tester.SetActive(true);
            tester.RaiseGameEvent(10f);

            Assert.AreEqual(10f, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(10f);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterFloatGameEvent()
        {
            var gameEvent = ScriptableObject.CreateInstance<FloatGameEvent>();
            var listener = new NoOpArgumentListener<float>();

            gameEvent.RegisterListener(listener);
            Assert.AreEqual(1, gameEvent.Listeners.Count());

            gameEvent.UnregisterListener(listener);
            Assert.AreEqual(0, gameEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseGameEventEvent()
        {
            // Given.
            var gameObject = new UnityEngine.GameObject();
            gameObject.SetActive(false);

            var listener = gameObject.AddComponent<GameEventListener>();

            listener.OnGameEvent = new UnityEvent();
            listener.GameEvent = ScriptableObject.CreateInstance<GameEvent>();

            var count = new int[1];
            listener.OnGameEvent.AddListener(() => count[0]++);

            // Then.
            gameObject.SetActive(true);
            listener.GameEvent.RaiseGameEvent();

            Assert.AreEqual(1, count[0]);
            count[0] = 0;

            gameObject.SetActive(false);
            listener.GameEvent.RaiseGameEvent();

            Assert.AreEqual(0, count[0]);
        }

        [Test]
        public void ShouldRegisterAndUnregisterGameObjectGameEvent()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameObjectGameEvent>();
            var listener = new NoOpArgumentListener<UnityEngine.GameObject>();

            gameEvent.RegisterListener(listener);
            Assert.AreEqual(1, gameEvent.Listeners.Count());

            gameEvent.UnregisterListener(listener);
            Assert.AreEqual(0, gameEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseGameObjectGameEventListener()
        {
            var tester = new GameEventTester<
                GameObjectGameEventListener,
                GameObjectGameEvent,
                GameObjectEvent,
                UnityEngine.GameObject
            >();

            tester.SetActive(true);

            var gameObject = new UnityEngine.GameObject();
            tester.RaiseGameEvent(gameObject);

            Assert.AreEqual(gameObject, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(gameObject);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterGameEvent()
        {
            var gameEvent = ScriptableObject.CreateInstance<GameEvent>();
            var listener = new NoOpListener();

            gameEvent.RegisterListener(listener);
            Assert.AreEqual(1, gameEvent.Listeners.Count());

            gameEvent.UnregisterListener(listener);
            Assert.AreEqual(0, gameEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseIntGameEventListener()
        {
            var tester = new GameEventTester<
                IntGameEventListener,
                IntGameEvent,
                IntEvent,
                int
            >();

            tester.SetActive(true);
            tester.RaiseGameEvent(10);

            Assert.AreEqual(10, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(10);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterIntGameEvent()
        {
            var gameEvent = ScriptableObject.CreateInstance<IntGameEvent>();
            var listener = new NoOpArgumentListener<int>();

            gameEvent.RegisterListener(listener);
            Assert.AreEqual(1, gameEvent.Listeners.Count());

            gameEvent.UnregisterListener(listener);
            Assert.AreEqual(0, gameEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseStringGameEventListener()
        {
            var tester = new GameEventTester<
                StringGameEventListener,
                StringGameEvent,
                StringEvent,
                string
            >();

            tester.SetActive(true);
            tester.RaiseGameEvent("foo");

            Assert.AreEqual("foo", tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent("foo");

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterStringGameEvent()
        {
            var gameEvent = ScriptableObject.CreateInstance<StringGameEvent>();
            var listener = new NoOpArgumentListener<string>();

            gameEvent.RegisterListener(listener);
            Assert.AreEqual(1, gameEvent.Listeners.Count());

            gameEvent.UnregisterListener(listener);
            Assert.AreEqual(0, gameEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseTransformGameEventListener()
        {
            var tester = new GameEventTester<
                TransformGameEventListener,
                TransformGameEvent,
                TransformEvent,
                UnityEngine.Transform
            >();

            tester.SetActive(true);

            var gameObject = new UnityEngine.GameObject();
            tester.RaiseGameEvent(gameObject.transform);

            Assert.AreEqual(gameObject.transform, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(gameObject.transform);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterTransformGameEvent()
        {
            var gameEvent = ScriptableObject.CreateInstance<TransformGameEvent>();
            var listener = new NoOpArgumentListener<UnityEngine.Transform>();

            gameEvent.RegisterListener(listener);
            Assert.AreEqual(1, gameEvent.Listeners.Count());

            gameEvent.UnregisterListener(listener);
            Assert.AreEqual(0, gameEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseVector2EventListener()
        {
            var tester = new GameEventTester<
                Vector2GameEventListener,
                Vector2GameEvent,
                Vector2Event,
                UnityEngine.Vector2
            >();

            tester.SetActive(true);
            tester.RaiseGameEvent(UnityEngine.Vector2.one);

            Assert.AreEqual(UnityEngine.Vector2.one, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(UnityEngine.Vector2.one);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterVector2GameEvent()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector2GameEvent>();
            var listener = new NoOpArgumentListener<UnityEngine.Vector2>();

            gameEvent.RegisterListener(listener);
            Assert.AreEqual(1, gameEvent.Listeners.Count());

            gameEvent.UnregisterListener(listener);
            Assert.AreEqual(0, gameEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRaiseVector3EventListener()
        {
            var tester = new GameEventTester<
                Vector3GameEventListener,
                Vector3GameEvent,
                Vector3Event,
                UnityEngine.Vector3
            >();

            tester.SetActive(true);
            tester.RaiseGameEvent(UnityEngine.Vector3.one);

            Assert.AreEqual(UnityEngine.Vector3.one, tester.GetLastEventValue());
            Assert.AreEqual(1, tester.GetEventCount());
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(UnityEngine.Vector3.one);

            Assert.AreEqual(0, tester.GetEventCount());
        }

        [Test]
        public void ShouldRegisterAndUnregisterVector3GameEvent()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector3GameEvent>();
            var listener = new NoOpArgumentListener<UnityEngine.Vector3>();

            gameEvent.RegisterListener(listener);
            Assert.AreEqual(1, gameEvent.Listeners.Count());

            gameEvent.UnregisterListener(listener);
            Assert.AreEqual(0, gameEvent.Listeners.Count());
        }

        [Test]
        public void ShouldRegisterAndUnregisterMultipleGameEvents()
        {
            var gameEvent = ScriptableObject.CreateInstance<Vector3GameEvent>();
            var firstListener = new NoOpArgumentListener<UnityEngine.Vector3>();
            var secondListener = new NoOpArgumentListener<UnityEngine.Vector3>();

            gameEvent.RegisterListener(firstListener);
            gameEvent.RegisterListener(secondListener);
            Assert.AreEqual(2, gameEvent.Listeners.Count());

            gameEvent.UnregisterListener(firstListener);
            gameEvent.UnregisterListener(secondListener);
            Assert.AreEqual(0, gameEvent.Listeners.Count());
        }
    }
}
