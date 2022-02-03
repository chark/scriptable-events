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
    public abstract class BaseScriptableEventListener<TArg>
        : BaseScriptableEventListener, IScriptableEventListener<TArg>
    {
        #region Editor

        [SerializeField]
        [Tooltip("ScriptableEvent that triggers the On Raised UnityEvent")]
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

        #region Public Methods

        public void OnRaised(TArg value)
        {
            onRaised.Invoke(value);
        }

        #endregion
    }

    /// <summary>
    /// Base Scriptable Event Listener which is implemented by all listener components and is used
    /// in internal editor scripts.
    /// </summary>
    [ScriptableIcon(ScriptableIconType.Listener)]
    public abstract class BaseScriptableEventListener : MonoBehaviour
    {
    }
}
