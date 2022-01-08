using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    [ScriptableEventIcon(IconName = "ListenerIcon")]
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

            scriptableEvent.AddListener(this);
        }

        private void OnDisable()
        {
            if (scriptableEvent == null)
            {
                return;
            }

            scriptableEvent.RemoveListener(this);
        }

        #endregion

        #region Methods

        public void OnRaised(TArg value)
        {
            onRaised.Invoke(value);
        }

        #endregion
    }
}
