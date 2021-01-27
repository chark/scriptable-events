using System;
using UnityEngine.Events;

namespace ScriptableEvents.Transform
{
    [Serializable]
    public class TransformUnityEvent : UnityEvent<UnityEngine.Transform>
    {
    }
}
