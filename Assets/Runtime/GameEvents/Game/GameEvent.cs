using System.Collections.Generic;
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

        private readonly List<IGameEventListener> listeners =
            new List<IGameEventListener>();

        public IEnumerable<IGameEventListener> Listeners => listeners;

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

                listener.RaiseGameEvent();
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
