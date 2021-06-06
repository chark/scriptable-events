using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    public abstract class BaseScriptableEventListener<TArg>
        : MonoBehaviour, IScriptableEventListener<TArg>
    {
        #region Editor

        [SerializeField]
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
                return;
            }

            scriptableEvent.Add(this);
        }

        private void OnDisable()
        {
            if (scriptableEvent == null)
            {
                // Can exit without logging as OnEnable should give enough info.
                return;
            }

            scriptableEvent.Remove(this);
        }

        #endregion

        #region Overrides

        public void OnRaised(TArg arg)
        {
            onRaised.Invoke(arg);
        }

        #endregion
    }
}
