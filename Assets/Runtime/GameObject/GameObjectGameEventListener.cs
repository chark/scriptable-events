using UnityEngine;

namespace GameEvents.GameObject
{
    [AddComponentMenu("Game Events/Game Object Game Event Listener")]
    public class GameObjectGameEventListener
        : BaseGameEventListener<GameObjectGameEvent, GameObjectUnityEvent, UnityEngine.GameObject>
    {
    }
}
