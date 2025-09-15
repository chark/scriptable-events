using System.Collections.Generic;
using UnityEngine;

namespace CHARK.ScriptableEvents.VisualScripting
{
    internal delegate void RaisedCallback<in TArg>(TArg arg);
    internal interface IListenerComponent<TArg>
    {
        void RegisterEvent(ScriptableEvent<TArg> evt);
        void RegisterEvents(List<ScriptableEvent<TArg>> events);
        void RegisterOnRaised(RaisedCallback<TArg> callback);
    }

    internal class ListenerComponent<TArg> : MonoBehaviour, IListenerComponent<TArg>, IScriptableEventListener<TArg>
    {
        private readonly List<ScriptableEvent<TArg>> events = new ();
        private RaisedCallback<TArg> onRaised;
        private bool isEnabled;

        private void OnEnable()
        {
            // Log(gameObject, "OnEnable");

            isEnabled = true;
            events.ForEach(elem => elem.AddListener(this));
        }

        private void OnDisable()
        {
            // Log(gameObject, "OnDisable");

            isEnabled = false;
            onRaised = null;
            events.ForEach(elem => elem.RemoveListener(this));
        }

        public void RegisterEvent(ScriptableEvent<TArg> evt)
        {
            // Log(gameObject, "SetListener");

            if (isEnabled)
            {
                evt.AddListener(this);
            }

            events.Add(evt);
        }

        public void RegisterEvents(List<ScriptableEvent<TArg>> events)
        {
            events.ForEach(RegisterEvent);
        }

        public void RegisterOnRaised(RaisedCallback<TArg> callback)
        {
            onRaised += callback;
        }

        public void OnRaised(TArg arg)
        {
            // Log(gameObject, $"OnRaised {{ arg: {arg} }}");

            onRaised(arg);
        }

        private static void Log(Object target, string message)
        {
            Debug.Log($"ListenerNode > {target.name} > {message}");
        }
    }
}
