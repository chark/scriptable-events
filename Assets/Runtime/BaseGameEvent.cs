using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace GameEvents
{
    public abstract class BaseGameEvent<TArg> : ScriptableObject, IGameEvent<TArg>
    {
        #region Editor

        [SerializeField]
        [Tooltip("Description of the game event")]
        private string description;

        [SerializeField]
        [Tooltip("Should exceptions be suppressed and continue the listener chain")]
        private bool suppressExceptions;

        // todo: show yellow warning
        [SerializeField]
        [Tooltip("Should debug messages be logged for this game event")]
        private bool trace;

        #endregion

        #region Fields

        // ReadOnlyCollection is used here so it wouldn't get modified via Listeners without having
        // to use Add or Remove.
        private readonly ReadOnlyCollection<IGameEventListener<TArg>> readOnlyListeners;

        private readonly List<IGameEventListener<TArg>> listeners
            = new List<IGameEventListener<TArg>>();

        #endregion

        #region Properties

        public ICollection<IGameEventListener<TArg>> Listeners => readOnlyListeners;

        #endregion

        #region Unity Lifecycle

        private void OnDisable()
        {
            listeners.Clear();
        }

        #endregion

        #region Methods

        protected BaseGameEvent()
        {
            readOnlyListeners = new ReadOnlyCollection<IGameEventListener<TArg>>(listeners);
        }

        public void Raise(TArg arg)
        {
            for (var i = listeners.Count - 1; i >= 0; i--)
            {
                var listener = listeners[i];

                if (trace)
                {
                    Trace(listener, arg);
                }

                if (suppressExceptions)
                {
                    OnRaiseSuppressed(listener, arg);
                }
                else
                {
                    OnRaise(listener, arg);
                }
            }
        }

        public void Add(IGameEventListener<TArg> listener)
        {
            if (listeners.Contains(listener))
            {
                return;
            }

            listeners.Add(listener);
        }

        public void Remove(IGameEventListener<TArg> listener)
        {
            listeners.Remove(listener);
        }

        private void Trace(IGameEventListener<TArg> listener, TArg arg)
        {
            Debug.Log($"Raise event: {name}, listener: {listener}, arg: {arg}", this);
        }

        private void OnRaiseSuppressed(IGameEventListener<TArg> listener, TArg arg)
        {
            try
            {
                listener.OnRaised(arg);
            }
            catch (Exception e)
            {
                Debug.LogError(
                    $"Listener: {listener} of event: {name} has thrown an exception.",
                    this
                );

                Debug.LogException(e, this);
            }
        }

        private static void OnRaise(IGameEventListener<TArg> listener, TArg arg)
        {
            listener.OnRaised(arg);
        }

        #endregion
    }
}
