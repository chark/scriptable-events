using UnityEngine;
using UnityEngine.Events;

namespace ScriptableEvents
{
    public class BaseScriptableEventListener<TScriptableEvent, TUnityEvent, TArg>
        : MonoBehaviour, IScriptableEventListener<TArg>
        where TScriptableEvent : BaseScriptableEvent<TArg>
        where TUnityEvent : UnityEvent<TArg>
    {
        #region Editor

        [SerializeField]
        private TScriptableEvent scriptableEvent;

        [Space]
        [SerializeField]
        private TUnityEvent onRaised;

        #endregion

        #region Unity Lifecycle

        private void OnEnable()
        {
            if (scriptableEvent == null)
            {
                Debug.LogError($"{typeof(TScriptableEvent).Name} is not assigned", this);
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
