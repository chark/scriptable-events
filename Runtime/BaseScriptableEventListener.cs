using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    public abstract class BaseScriptableEventListener<TArg>
        : MonoBehaviour, IScriptableEventListener<TArg>
    {
        #region Editor

        [SerializeField]
        [Tooltip("ScriptableEvent that triggers the onRaised UnityEvent")]
        private BaseScriptableEvent<TArg> scriptableEvent;

        [Space]
        [SerializeField]
        private UnityEvent<TArg> onRaised;

        #endregion

        #region Unity Lifecycle

        private void OnEnable()
        {
            if (scriptableEvent == null)
            {
                Debug.LogError("ScriptableEvent is not assigned", this);
                enabled = false;
                return;
            }

            scriptableEvent.Add(this);
        }

        private void OnDisable()
        {
            if (scriptableEvent == null)
            {
                return;
            }

            scriptableEvent.Remove(this);
        }

        #endregion

        #region Public Methods

        public void OnRaised(TArg arg)
        {
            if (scriptableEvent.Trace)
            {
                LogOnRaised(arg);
            }

            onRaised.Invoke(arg);
        }

        #endregion

        #region Private Methods

        private void LogOnRaised(TArg arg)
        {
            Debug.Log($"Raised: {name}, arg: {arg}", this);
        }

        #endregion
    }
}
