using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.GameObject
{
    [CreateAssetMenu(fileName = "GameObjectEvent", menuName = "Game Events/Game Object Event")]
    public class GameObjectGameEvent : ArgumentGameEvent<UnityEngine.GameObject>
    {
    }
}
