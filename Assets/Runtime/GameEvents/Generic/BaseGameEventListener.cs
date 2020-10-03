using UnityEngine;
using UnityEngine.Events;

namespace GameEvents.Generic
{
    public abstract class BaseGameEventListener<TGameEvent>
        : MonoBehaviour, IGameEventListener
        where TGameEvent : IGameEvent
    {
        [SerializeField]
        [Tooltip("Game event to listen to which will trigger the onGameEvent event")]
        private TGameEvent gameEvent = default;

        [SerializeField]
        [Tooltip("Called when the listener is triggered with an argument")]
        private UnityEvent onGameEvent = default;

        private void OnEnable()
        {
            if (gameEvent == null)
            {
                Debug.LogWarning($"Game Event on listener {name} is not set");
                return;
            }

            gameEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            if (gameEvent == null)
            {
                Debug.LogWarning($"Game Event on listener {name} is not set");
                return;
            }

            gameEvent.UnregisterListener(this);
        }

        public void OnGameEvent()
        {
            onGameEvent.Invoke();
        }
    }
}
