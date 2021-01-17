using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.Game
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Game Events/Game Event")]
    public class GameEvent : ScriptableObject, IGameEvent
    {
        [SerializeField]
        [Tooltip("Should debug messages be logged for this event")]
        private bool debug = false;

        private readonly ReadOnlyCollection<IGameEventListener> readListeners;

        private readonly List<IGameEventListener> listeners =
            new List<IGameEventListener>();

        public ICollection<IGameEventListener> Listeners => readListeners;

        public GameEvent()
        {
            readListeners = listeners.AsReadOnly();
        }

        public void RaiseGameEvent()
        {
            if (debug)
            {
                Debug.Log($"Raise event: {name}");
            }

            for (var i = listeners.Count - 1; i >= 0; i--)
            {
                var listener = listeners[i];
                if (debug)
                {
                    Debug.Log($"Raise event: {name}, listener: {listener}");
                }

                try
                {
                    listener.RaiseGameEvent();
                }
                catch (Exception e)
                {
                    Debug.Log($"Listener: {listener} of event: {name} has thrown an exception.");
                    Debug.LogException(e, this);
                }
            }
        }

        public void RegisterListener(IGameEventListener listener)
        {
            if (debug)
            {
                Debug.Log($"Registering listener: {listener}");
            }

            listeners.Add(listener);
        }

        public void UnregisterListener(IGameEventListener listener)
        {
            if (debug)
            {
                Debug.Log($"Unregistering listener: {listener}");
            }

            listeners.Remove(listener);
        }
    }
}
