using UnityEngine;
using UnityEngine.Events;

namespace GameEvents.Generic
{
    public abstract class ArgumentGameEventListener<TGameEvent, TUnityEvent, TArgument>
        : MonoBehaviour, IArgumentGameEventListener<TArgument>
        where TGameEvent : IArgumentGameEvent<TArgument>
        where TUnityEvent : UnityEvent<TArgument>
    {
        [SerializeField]
        [Tooltip("Game event to listen to which will trigger the onGameEvent event")]
        private TGameEvent gameEvent = default;

        // ReSharper disable once Unity.RedundantSerializeFieldAttribute
        // ReSharper disable once FieldCanBeMadeReadOnly.Local
        [SerializeField]
        [Tooltip("Called when the listener is triggered with an argument")]
        private TUnityEvent onGameEvent = default;

        /// <summary>
        ///     Get or set the underlying GameEvent.
        /// </summary>
        public TGameEvent GameEvent
        {
            get => gameEvent;
            set => gameEvent = value;
        }

        /// <summary>
        ///     Get or set the underlying UnityEvent.
        /// </summary>
        public TUnityEvent OnGameEvent
        {
            get => onGameEvent;
            set => onGameEvent = value;
        }

        /// <summary>
        ///     Trigger this listener with an argument.
        /// </summary>
        public void RaiseGameEvent(TArgument argument)
        {
            onGameEvent.Invoke(argument);
        }

        private void OnEnable()
        {
            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            gameEvent.UnregisterListener(this);
        }
    }
}
