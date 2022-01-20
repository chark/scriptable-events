using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;
using Object = UnityEngine.Object;

namespace ScriptableEvents
{
    /// <summary>
    /// Base scriptable event, used to define internal and custom events.
    /// </summary>
    /// <typeparam name="TArg">
    /// Type of data which is passed as an argument to this event
    /// </typeparam>
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

        #region Private Fields

        private readonly List<Action<TArg>> listeners =
            new List<Action<TArg>>();

        #endregion

        #region Internal Properties

        internal override IEnumerable<object> Listeners => listeners
            .Select(invocation => invocation.Target)
            .ToList();

        internal override int ListenerCount => listeners.Count;

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
                Raise(listener, value);
            }
        }

        /// <summary>
        /// Add a listener to this event.
        /// </summary>
        public void AddListener(IScriptableEventListener<TArg> listener)
        {
            AddListener(listener.OnRaised);
        }

        /// <summary>
        /// Add a listener action to this event.
        /// </summary>
        public void AddListener(Action<TArg> listener)
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
            RemoveListener(listener.OnRaised);
        }

        /// <summary>
        /// Remove a listener action from this event.
        /// </summary>
        public void RemoveListener(Action<TArg> listener)
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

        #region Internal Methods

        /// <summary>
        /// Raise this event with an argument by triggering only the specified listener. This is
        /// used in internal inspector GUI scripts.
        /// </summary>
        internal void Raise(TArg value, int listenerIndex)
        {
            var listener = listeners[listenerIndex];
            Raise(listener, value);
        }

        #endregion

        #region Private Methods

        private void Raise(Action<TArg> listener, TArg value)
        {
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

        private void OnRaiseSuppressed(Action<TArg> listener, TArg value)
        {
            try
            {
                listener.Invoke(value);
            }
            catch (Exception exception)
            {
                var context = GetLogContext(listener);
                Debug.LogException(exception, context);
            }
        }

        private static void OnRaise(Action<TArg> listener, TArg value)
        {
            listener.Invoke(value);
        }

        #endregion

        #region Private Logging Methods

        private void LogRaise(Action<TArg> listener, TArg value)
        {
            var context = GetLogContext(listener);
            Debug.Log($"{name}: raise listener {listener.Target} with value {value}", context);
        }

        private void LogAdd(Action<TArg> listener)
        {
            var context = GetLogContext(listener);
            Debug.Log($"{name}: adding listener {listener.Target}", context);
        }

        private void LogRemove(Action<TArg> listener)
        {
            var context = GetLogContext(listener);
            Debug.Log($"{name}: removing listener {listener.Target}", context);
        }

        private void LogRemove()
        {
            Debug.Log($"{name}: removing listeners", this);
        }

        private Object GetLogContext(Action<TArg> listener)
        {
            var target = listener.Target;
            if (target is Object targetObject)
            {
                return targetObject;
            }

            return this;
        }

        #endregion
    }
}
