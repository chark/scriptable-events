using System;
using UnityEngine.Events;

namespace GameEvents.Transform
{
    [Serializable]
    public class TransformEvent : UnityEvent<UnityEngine.Transform>
    {
    }
}
