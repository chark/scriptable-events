using System;
using UnityEngine.Events;

namespace ScriptableEvents.Simple
{
    [Serializable]
    public class SimpleUnityEvent : UnityEvent<SimpleArg>
    {
    }
}
