using System;
using UnityEngine.Events;

namespace GameEvents.GameObject
{
    [Serializable]
    public class GameObjectEvent : UnityEvent<UnityEngine.GameObject>
    {
    }
}
