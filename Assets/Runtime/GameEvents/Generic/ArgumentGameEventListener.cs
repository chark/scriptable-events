using UnityEngine;
using UnityEngine.Events;

namespace GameEvents.Generic
{
    public abstract class ArgumentGameEventListener<TGameEvent, TUnityEvent, TArgument>
        : MonoBehaviour, IArgumentGameEventListener<TArgument>
        where TGameEvent : IArgumentGameEvent<TArgument>
        where TUnityEvent : UnityEvent<TArgument>
    {
        #region Public Methods

        /// <summary>
        ///     Trigger this listener with an argument.
        /// </summary>
        public void OnGameEvent(TArgument argument)
        {
            onGameEvent.Invoke(argument);
        }

        #endregion

        #region Private Fields

        [SerializeField]
        [Tooltip("Game event to listen to which will trigger the onGameEvent event")]
        private TGameEvent gameEvent = default;

        // ReSharper disable once Unity.RedundantSerializeFieldAttribute
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        [SerializeField]
        [Tooltip("Called when the listener is triggered with an argument")]
        private TUnityEvent onGameEvent = default;

        #endregion

        #region Unity Event Methods

        private void OnEnable()
        {
            if (gameEvent == null)
            {
                Debug.LogWarning(
                    $"Game Event ({typeof(TGameEvent).Name}) on listener {name} is not set"
                );

                return;
            }

            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (gameEvent == null)
            {
                Debug.LogWarning(
                    $"Game Event ({typeof(TGameEvent).Name}) on listener {name} is not set"
                );

                return;
            }

            gameEvent.UnregisterListener(this);
        }

        #endregion
    }
}
