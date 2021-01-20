using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    public class BaseGameEventListener<TGameEvent, TUnityEvent, TArg>
        : MonoBehaviour, IGameEventListener<TArg>
        where TGameEvent : BaseGameEvent<TArg>
        where TUnityEvent : UnityEvent<TArg>
    {
        #region Editor

        [SerializeField]
        private TGameEvent gameEvent;

        [Space]
        [SerializeField]
        private TUnityEvent onRaised;

        #endregion

        #region Unity Lifecycle

        private void OnEnable()
        {
            if (gameEvent == null)
            {
                Debug.LogError($"{typeof(TGameEvent).Name} is not assigned", this);
                return;
            }

            gameEvent.Add(this);
        }

        private void OnDisable()
        {
            if (gameEvent == null)
            {
                // Can exit without logging as OnEnable should give enough info.
                return;
            }

            gameEvent.Remove(this);
        }

        #endregion

        #region Methods

        public void OnRaised(TArg arg)
        {
            onRaised.Invoke(arg);
        }

        #endregion
    }
}
