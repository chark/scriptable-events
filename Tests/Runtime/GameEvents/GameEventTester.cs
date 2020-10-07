using System.Collections.Generic;
using System.Linq;
using GameEvents.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    public class GameEventTester<
        TGameEventListener,
        TGameEvent,
        TUnityEvent,
        TArgument
    >
        where TGameEvent : ArgumentGameEvent<TArgument>
        where TUnityEvent : UnityEvent<TArgument>, new()
        where TGameEventListener : ArgumentGameEventListener<
            TGameEvent,
            TUnityEvent,
            TArgument
        >
    {
        private readonly List<TArgument> eventValues;
        private readonly UnityEngine.GameObject gameObject;
        private readonly TGameEvent gameEvent;

        public GameEventTester()
        {
            eventValues = new List<TArgument>();

            gameObject = new UnityEngine.GameObject();
            gameObject.SetActive(false);

            var onGameEvent = new TUnityEvent();
            onGameEvent.AddListener(AddEventValue);

            gameEvent = ScriptableObject.CreateInstance<TGameEvent>();

            var listener = gameObject.AddComponent<TGameEventListener>();
            listener.OnGameEvent = onGameEvent;
            listener.GameEvent = gameEvent;
        }

        public int GetEventCount()
        {
            return eventValues.Count;
        }

        public TArgument GetLastEventValue()
        {
            return eventValues.Last();
        }

        public void Clear()
        {
            eventValues.Clear();
        }

        public void SetActive(bool value)
        {
            gameObject.SetActive(value);
        }

        public void RaiseGameEvent(TArgument argument)
        {
            gameEvent.RaiseGameEvent(argument);
        }

        private void AddEventValue(TArgument value)
        {
            eventValues.Add(value);
        }
    }
}
