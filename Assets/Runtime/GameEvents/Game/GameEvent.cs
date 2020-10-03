using System.Collections.Generic;
using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.Game
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Game Events/Game Event")]
    public class GameEvent : ScriptableObject, IGameEvent
    {
        #region Private Fields

        [SerializeField]
        [Tooltip("Should debug messages be logged for this event")]
        private bool debug = false;

        private readonly List<IGameEventListener> listeners =
            new List<IGameEventListener>();

        #endregion

        #region Public Methods

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

                listener.OnGameEvent();
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

        #endregion
    }
}
