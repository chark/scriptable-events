using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    /// <summary>
    /// Base Scriptable Event Listener which accepts an argument, used as a base by all internal
    /// and custom listener components.
    /// </summary>
    /// <typeparam name="TArg">
    /// Type of data which is passed as an argument to this listener
    /// </typeparam>
    public abstract class ScriptableEventListener<TArg>
        : ScriptableEventListener, IScriptableEventListener<TArg>, ISerializationCallbackReceiver
    {
        #region Editor
        [HideInInspector]
        [SerializeField]
        [Obsolete]
        [Tooltip("ScriptableEvent that triggers the On Raised UnityEvent")]
        private ScriptableEvent<TArg> scriptableEvent;

        [SerializeField]
        [Tooltip("List of ScriptableEvents that trigger the On Raised UnityEvent")]
        private List<ScriptableEvent<TArg>> scriptableEvents = new List<ScriptableEvent<TArg>>();

        [Space]
        [SerializeField]
        private UnityEvent<TArg> onRaised;

        #endregion

        #region Unity Lifecycle

        private void OnEnable()
        {
            // No null or empty check - a listener can exist with that is listening to nothing.
            // This also avoids issues on initialisation
            scriptableEvents.ForEach(scriptableEvent => scriptableEvent.AddListener(this));
        }

        private void OnDisable()
        {
            scriptableEvents.ForEach(scriptableEvent => scriptableEvent.RemoveListener(this));
        }

        #endregion

        #region Public Methods

        public void OnRaised(TArg value)
        {
            onRaised.Invoke(value);
        }

        public void OnBeforeSerialize()
        {
            // Move from the old single event model to the new model.
            if (Application.isPlaying)
            {
                return;
            }
            if (scriptableEvent!=false)
            {
                if (!scriptableEvents.Contains(scriptableEvent))
                {
                    scriptableEvents.Add(scriptableEvent);
                }
                scriptableEvent = null;
            }
        }

        public void OnAfterDeserialize()
        {
        }

        #endregion
    }

    /// <summary>
    /// Base Scriptable Event Listener which is implemented by all listener components and is used
    /// in internal editor scripts.
    /// </summary>
    [ScriptableIcon(ScriptableIconType.Listener)]
    public abstract class ScriptableEventListener : MonoBehaviour
    {
    }
}
