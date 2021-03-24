using System;
using UnityEngine.Events;

namespace ScriptableEvents.Collision
{
    [Serializable]
    public class CollisionUnityEvent : UnityEvent<UnityEngine.Collision>
    {
    }
}
