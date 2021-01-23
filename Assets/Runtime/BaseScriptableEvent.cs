using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEvents
{
    public abstract class BaseScriptableEvent<TArg> : ScriptableObject, IScriptableEvent<TArg>
    {
        #region Editor

        // ReSharper disable once NotAccessedField.Local
        [SerializeField]
        private string description;

        // ReSharper disable once NotAccessedField.Local
        [SerializeField]
        private bool lockDescription = true;

        [SerializeField]
        private bool suppressExceptions;

        [SerializeField]
        private bool trace;

        #endregion

        #region Fields

        [NonSerialized]
        private readonly List<IScriptableEventListener<TArg>> listeners
            = new List<IScriptableEventListener<TArg>>();

        #endregion

        #region Unity Lifecycle

        private void OnDisable()
        {
            listeners.Clear();
        }

        #endregion

        #region Methods

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

        public void Clear()
        {
            listeners.Clear();
        }

        /// <inheritdoc cref="BaseScriptableEvent{TArg}.Add"/>
        public static BaseScriptableEvent<TArg> operator +(
            BaseScriptableEvent<TArg> scriptableEvent,
            IScriptableEventListener<TArg> scriptableEventListener
        )
        {
            scriptableEvent.Add(scriptableEventListener);
            return scriptableEvent;
        }

        /// <inheritdoc cref="BaseScriptableEvent{TArg}.Remove"/>
        public static BaseScriptableEvent<TArg> operator -(
            BaseScriptableEvent<TArg> scriptableEvent,
            IScriptableEventListener<TArg> scriptableEventListener
        )
        {
            scriptableEvent.Remove(scriptableEventListener);
            return scriptableEvent;
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
