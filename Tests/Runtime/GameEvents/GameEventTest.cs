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

            Assert.AreEqual(tester.GetLastEventValue(), true);
            Assert.AreEqual(tester.GetEventCount(), 1);
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(true);

            Assert.AreEqual(tester.GetEventCount(), 0);
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

            Assert.AreEqual(tester.GetLastEventValue(), 10f);
            Assert.AreEqual(tester.GetEventCount(), 1);
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(10f);

            Assert.AreEqual(tester.GetEventCount(), 0);
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

            Assert.AreEqual(count[0], 1);
            count[0] = 0;

            gameObject.SetActive(false);
            listener.GameEvent.RaiseGameEvent();

            Assert.AreEqual(count[0], 0);
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

            Assert.AreEqual(tester.GetLastEventValue(), gameObject);
            Assert.AreEqual(tester.GetEventCount(), 1);
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(gameObject);

            Assert.AreEqual(tester.GetEventCount(), 0);
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

            Assert.AreEqual(tester.GetLastEventValue(), 10);
            Assert.AreEqual(tester.GetEventCount(), 1);
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(10);

            Assert.AreEqual(tester.GetEventCount(), 0);
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

            Assert.AreEqual(tester.GetLastEventValue(), "foo");
            Assert.AreEqual(tester.GetEventCount(), 1);
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent("foo");

            Assert.AreEqual(tester.GetEventCount(), 0);
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

            Assert.AreEqual(tester.GetLastEventValue(), gameObject.transform);
            Assert.AreEqual(tester.GetEventCount(), 1);
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(gameObject.transform);

            Assert.AreEqual(tester.GetEventCount(), 0);
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

            Assert.AreEqual(tester.GetLastEventValue(), UnityEngine.Vector2.one);
            Assert.AreEqual(tester.GetEventCount(), 1);
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(UnityEngine.Vector2.one);

            Assert.AreEqual(tester.GetEventCount(), 0);
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

            Assert.AreEqual(tester.GetLastEventValue(), UnityEngine.Vector3.one);
            Assert.AreEqual(tester.GetEventCount(), 1);
            tester.Clear();

            tester.SetActive(false);
            tester.RaiseGameEvent(UnityEngine.Vector3.one);

            Assert.AreEqual(tester.GetEventCount(), 0);
        }
    }
}
