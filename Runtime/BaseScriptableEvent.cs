using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEvents
{
    public abstract class BaseScriptableEvent<TArg> : ScriptableObject
    {
        #region Editor

        // ReSharper disable once NotAccessedField.Local
        [SerializeField, TextArea]
        [Tooltip("Custom description to provide more additional information")]
        private string description;

#pragma warning disable CS0414

        // ReSharper disable once NotAccessedField.Local
        [SerializeField, HideInInspector]
        private bool lockDescription = true;

#pragma warning restore CS0414

        [SerializeField]
        [Tooltip("Should exceptions not break the listener chain")]
        private bool suppressExceptions;

        [SerializeField]
        [Tooltip(
            "Should additional trace information be logged. Enabling this will degrade performance!"
        )]
        private bool trace;

        #endregion

        #region Fields

        private readonly List<IScriptableEventListener<TArg>> listeners =
            new List<IScriptableEventListener<TArg>>();

        #endregion

        #region Unity Lifecycle

        private void OnDisable()
        {
            RemoveListeners();
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Raise this event with an argument.
        /// </summary>
        public void Raise(TArg value)
        {
            for (var index = listeners.Count - 1; index >= 0; index--)
            {
                var listener = listeners[index];

                if (trace)
                {
                    LogRaise(listener, value);
                }

                if (suppressExceptions)
                {
                    OnRaiseSuppressed(listener, value);
                }
                else
                {
                    OnRaise(listener, value);
                }
            }
        }

        /// <summary>
        /// Add a listener to this event.
        /// </summary>
        public void AddListener(IScriptableEventListener<TArg> listener)
        {
            if (trace)
            {
                LogAdd(listener);
            }

            listeners.Add(listener);
        }

        /// <summary>
        /// Remove a listener from this event.
        /// </summary>
        public void RemoveListener(IScriptableEventListener<TArg> listener)
        {
            if (trace)
            {
                LogRemove(listener);
            }

            listeners.Remove(listener);
        }

        /// <summary>
        /// Remove all listeners from this event.
        /// </summary>
        public void RemoveListeners()
        {
            if (trace)
            {
                LogRemove();
            }

            listeners.Clear();
        }

        #endregion

        #region Private Methods

        private void OnRaiseSuppressed(IScriptableEventListener<TArg> listener, TArg value)
        {
            try
            {
                listener.OnRaised(value);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception, this);
            }
        }

        private static void OnRaise(IScriptableEventListener<TArg> listener, TArg value)
        {
            listener.OnRaised(value);
        }

        #endregion

        #region Private Logging Methods

        private void LogRaise(IScriptableEventListener<TArg> listener, TArg value)
        {
            Debug.Log($"Raise listener: {listener}, value: {value}", this);
        }

        private void LogAdd(IScriptableEventListener<TArg> listener)
        {
            Debug.Log($"Adding listener: {listener}", this);
        }

        private void LogRemove(IScriptableEventListener<TArg> listener)
        {
            Debug.Log($"Removing listener: {listener}", this);
        }

        private void LogRemove()
        {
            Debug.Log("Removing listeners", this);
        }

        #endregion
    }
}
