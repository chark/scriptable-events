using System;
using System.Collections.Generic;
using UnityEngine;

namespace ScriptableEvents
{
    public abstract class BaseScriptableEvent<TArg> : ScriptableObject, IScriptableEvent<TArg>
    {
        #region Editor

        // ReSharper disable once NotAccessedField.Local
        [SerializeField, TextArea]
        [Tooltip("Custom description to provide more additional information")]
        private string description;

        // ReSharper disable once NotAccessedField.Local
        [SerializeField, HideInInspector]
        private bool lockDescription = true;

        [SerializeField]
        [Tooltip("Should exceptions not break the listener chain")]
        private bool suppressExceptions;

        [SerializeField]
        [Tooltip("Should additional trace information be logged")]
        private bool trace;

        #endregion

        #region Fields

        [NonSerialized]
        private readonly List<IScriptableEventListener<TArg>> listeners
            = new List<IScriptableEventListener<TArg>>();

#if UNITY_EDITOR
        private readonly List<object> rawEditorListeners
            = new List<object>();
#endif

        #endregion

        #region Properties

#if UNITY_EDITOR
        ICollection<object> IScriptableEvent<TArg>.RawEditorListeners => rawEditorListeners;
#endif

        #endregion

        #region Unity Lifecycle

        private void OnDisable()
        {
            Clear();
        }

        #endregion

        #region Overrides

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

#if UNITY_EDITOR
            rawEditorListeners.Add(listener);
#endif
            listeners.Add(listener);
        }

        public void Remove(IScriptableEventListener<TArg> listener)
        {
#if UNITY_EDITOR
            rawEditorListeners.Remove(listener);
#endif
            listeners.Remove(listener);
        }

        public void Clear()
        {
#if UNITY_EDITOR
            rawEditorListeners.Clear();
#endif
            listeners.Clear();
        }

        #endregion

        #region Methods

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
