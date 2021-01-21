using UnityEngine;

namespace GameEvents.Transform
{
    [AddComponentMenu("Game Events/Transform Game Event Listener")]
    public class TransformGameEventListener
        : BaseGameEventListener<TransformGameEvent, TransformUnityEvent, UnityEngine.Transform>
    {
    }
}
