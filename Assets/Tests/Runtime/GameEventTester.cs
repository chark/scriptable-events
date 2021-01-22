using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents.Tests
{
    public class ScriptableEventTester<
        TScriptableEventListener,
        TScriptableEvent,
        TUnityEvent,
        TArgument
    >
        where TScriptableEvent : BaseScriptableEvent<TArgument>
        where TUnityEvent : UnityEvent<TArgument>, new()
        where TScriptableEventListener : BaseScriptableEventListener<
            TScriptableEvent,
            TUnityEvent,
            TArgument
        >
    {
        private readonly List<TArgument> eventValues;
        private readonly UnityEngine.GameObject gameObject;
        private readonly TScriptableEvent ScriptableEvent;

        public ScriptableEventTester()
        {
            eventValues = new List<TArgument>();

            gameObject = new UnityEngine.GameObject();
            gameObject.SetActive(false);

            var onScriptableEvent = new TUnityEvent();
            onScriptableEvent.AddListener(AddEventValue);

            ScriptableEvent = ScriptableObject.CreateInstance<TScriptableEvent>();

            var listener = gameObject.AddComponent<TScriptableEventListener>();

            // todo: do we need these in the API as its only for tests atm?
            // listener.OnScriptableEvent = onScriptableEvent;
            // listener.ScriptableEvent = ScriptableEvent;
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

        public void RaiseScriptableEvent(TArgument argument)
        {
            ScriptableEvent.Raise(argument);
        }

        private void AddEventValue(TArgument value)
        {
            eventValues.Add(value);
        }
    }
}
