using System.Collections.Generic;
using UnityEngine;

namespace GameEvents.Generic
{
    public abstract class ArgumentGameEvent<TArgument>
        : ScriptableObject, IArgumentGameEvent<TArgument>
    {
        #region Private Fields

        [SerializeField]
        [Tooltip("Should debug messages be logged for this event")]
        private bool debug = false;

        private readonly List<IArgumentGameEventListener<TArgument>> listeners =
            new List<IArgumentGameEventListener<TArgument>>();

        #endregion

        #region Public Methods

        public void RaiseGameEvent(TArgument argument)
        {
            if (debug)
            {
                Debug.Log($"Raise event: {name} with an argument: {argument}");
            }

            for (var i = listeners.Count - 1; i >= 0; i--)
            {
                var listener = listeners[i];
                if (debug)
                {
                    Debug.Log($"Raise event: {name}, listener: {listener}, argument: {argument}");
                }

                listener.OnGameEvent(argument);
            }
        }

        public void RegisterListener(IArgumentGameEventListener<TArgument> listener)
        {
            if (debug)
            {
                Debug.Log($"Registering listener: {listener}");
            }

            listeners.Add(listener);
        }

        public void UnregisterListener(IArgumentGameEventListener<TArgument> listener)
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
