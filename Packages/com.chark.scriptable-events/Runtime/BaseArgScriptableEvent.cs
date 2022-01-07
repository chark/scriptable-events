using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace ScriptableEvents
{
    public abstract class BaseScriptableEvent<TArg> : BaseScriptableEvent
    {
        #region Editor

        // ReSharper disable once NotAccessedField.Local
        [SerializeField, TextArea]
        [Tooltip("Custom description to provide more additional information")]
        private string description;

        [FormerlySerializedAs("suppressExceptions")]
        [SerializeField]
        [Tooltip("Should exceptions not break the listener chain")]
        private bool isSuppressExceptions;

        [FormerlySerializedAs("trace")]
        [SerializeField]
        [Tooltip(
            "Should additional debug information be logged. Enabling this will degrade performance!"
        )]
        private bool isDebug;

        #endregion

        #region Fields

        private readonly List<IScriptableEventListener<TArg>> listeners =
            new List<IScriptableEventListener<TArg>>();

        #endregion

        #region Internal Properties

        internal override IEnumerable Listeners => listeners;

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

                if (isDebug)
                {
                    LogRaise(listener, value);
                }

                if (isSuppressExceptions)
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
            if (isDebug)
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
            if (isDebug)
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
            if (isDebug)
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
