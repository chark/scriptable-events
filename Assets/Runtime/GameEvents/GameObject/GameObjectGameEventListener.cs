using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.GameObject
{
    [AddComponentMenu("Game Events/Game Object Game Event Listener")]
    public class GameObjectGameEventListener
        : ArgumentGameEventListener<GameObjectGameEvent, GameObjectEvent, UnityEngine.GameObject>
    {
    }
}
