﻿using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ScriptableEvents
{
    public abstract class BaseScriptableEvent<TArg> : ScriptableObject, IScriptableEvent<TArg>
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
        [Tooltip("Should additional trace information be logged")]
        private bool trace;

        #endregion

        #region Fields

        private readonly List<Action<TArg>> listeners = new List<Action<TArg>>();

#if UNITY_EDITOR
        private readonly List<Object> listenerObjects = new List<Object>();
#endif

        #endregion

        #region Properties

        internal bool Trace => trace;

#if UNITY_EDITOR
        // ReSharper disable once UnusedMember.Local
        private IReadOnlyList<Object> ListenerObjects => listenerObjects;

        // ReSharper disable once UnusedMember.Local
        private int ListenerCount => listeners.Count;
#endif

        #endregion

        #region Unity Lifecycle

        private void OnDisable()
        {
            Clear();
        }

        #endregion

        #region Public Methods

        public void Raise(TArg arg)
        {
            if (trace)
            {
                LogRaise(arg);
            }

            for (var index = listeners.Count - 1; index >= 0; index--)
            {
                var listener = listeners[index];

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
            if (trace)
            {
                LogAdd(listener);
            }

#if UNITY_EDITOR
            AddListenerObject(listener);
#endif

            listeners.Add(listener.OnRaised);
        }

        public void Add(Action<TArg> listener)
        {
            if (trace)
            {
                LogAdd();
            }

            listeners.Add(listener);
        }

        public void Remove(IScriptableEventListener<TArg> listener)
        {
            if (trace)
            {
                LogRemove(listener);
            }

#if UNITY_EDITOR
            RemoveListenerObject(listener);
#endif
            listeners.Remove(listener.OnRaised);
        }

        public void Remove(Action<TArg> listener)
        {
            if (trace)
            {
                LogRemove();
            }

            listeners.Remove(listener);
        }

        public void Clear()
        {
            if (trace)
            {
                LogClear();
            }

#if UNITY_EDITOR
            ClearListenerObjects();
#endif
            listeners.Clear();
        }

        #endregion

        #region Private Methods

        private void OnRaiseSuppressed(Action<TArg> listener, TArg arg)
        {
            try
            {
                listener.Invoke(arg);
            }
            catch (Exception exception)
            {
                Debug.LogException(exception, this);
            }
        }

        private static void OnRaise(Action<TArg> listener, TArg arg)
        {
            listener.Invoke(arg);
        }

#if UNITY_EDITOR
        private void AddListenerObject(IScriptableEventListener<TArg> listener)
        {
            if (listener is Object listenerObject)
            {
                listenerObjects.Add(listenerObject);
            }
        }

        private void RemoveListenerObject(IScriptableEventListener<TArg> listener)
        {
            if (listener is Object listenerObject)
            {
                listenerObjects.Remove(listenerObject);
            }
        }

        private void ClearListenerObjects()
        {
            listenerObjects.Clear();
        }
#endif

        #endregion

        #region Private Logging Methods

        private void LogRaise(TArg arg)
        {
            Debug.Log($"Raise arg: {arg}", this);
        }

        private void LogAdd(object listener = null)
        {
            if (listener is Object listenerObject)
            {
                Debug.Log($"Adding listener: {listenerObject.name}", this);
            }
            else
            {
                Debug.Log("Adding listener", this);
            }
        }

        private void LogRemove(object listener = null)
        {
            if (listener is Object listenerObject)
            {
                Debug.Log($"Adding listener: {listenerObject.name}", this);
            }
            else
            {
                Debug.Log("Removing listener", this);
            }
        }

        private void LogClear()
        {
            Debug.Log("Clearing listeners", this);
        }

        #endregion
    }
}
