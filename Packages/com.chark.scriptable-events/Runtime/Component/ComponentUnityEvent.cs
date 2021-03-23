using System;
using UnityEngine.Events;

namespace ScriptableEvents.Component
{
    [Serializable]
    public class ComponentUnityEvent : UnityEvent<UnityEngine.Component>
    {
    }
}
