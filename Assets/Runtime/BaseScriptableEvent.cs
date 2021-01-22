using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace ScriptableEvents
{
    public abstract class BaseScriptableEvent<TArg> : ScriptableObject, IScriptableEvent<TArg>
    {
        #region Editor

        [SerializeField]
        private string description;

        [SerializeField]
        private bool lockDescription = true;

        [SerializeField]
        private bool suppressExceptions;

        [SerializeField]
        private bool trace;

        #endregion

        #region Fields

        // ReadOnlyCollection is used here so it wouldn't get modified via Listeners without having
        // to use Add or Remove.
        private readonly ReadOnlyCollection<IScriptableEventListener<TArg>> readOnlyListeners;

        private readonly List<IScriptableEventListener<TArg>> listeners
            = new List<IScriptableEventListener<TArg>>();

        #endregion

        #region Properties

        public ICollection<IScriptableEventListener<TArg>> Listeners => readOnlyListeners;

        #endregion

        #region Unity Lifecycle

        private void OnDisable()
        {
            listeners.Clear();
        }

        #endregion

        #region Methods

        protected BaseScriptableEvent()
        {
            readOnlyListeners = new ReadOnlyCollection<IScriptableEventListener<TArg>>(listeners);
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

        public void Add(IScriptableEventListener<TArg> listener)
        {
            if (listeners.Contains(listener))
            {
                return;
            }

            listeners.Add(listener);
        }

        public void Remove(IScriptableEventListener<TArg> listener)
        {
            listeners.Remove(listener);
        }

        private void Trace(IScriptableEventListener<TArg> listener, TArg arg)
        {
            Debug.Log($"Raise event: {name}, listener: {listener}, arg: {arg}", this);
        }

        private void OnRaiseSuppressed(IScriptableEventListener<TArg> listener, TArg arg)
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

        private static void OnRaise(IScriptableEventListener<TArg> listener, TArg arg)
        {
            listener.OnRaised(arg);
        }

        #endregion
    }
}
