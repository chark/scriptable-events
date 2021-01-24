using System;
using UnityEngine.Events;

namespace ScriptableEvents.Samples.CustomEvents
{
    [Serializable]
    public class MaterialDataUnityEvent : UnityEvent<MaterialData>
    {
    }
}
