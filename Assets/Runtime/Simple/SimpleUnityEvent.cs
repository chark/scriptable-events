using System;
using UnityEngine.Events;

namespace GameEvents.Simple
{
    [Serializable]
    public class SimpleUnityEvent : UnityEvent<SimpleArg>
    {
    }
}
