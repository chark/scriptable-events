using UnityEngine;

namespace GameEvents.Transform
{
    [CreateAssetMenu(
        fileName = "TransformGameEvent",
        menuName = "Game Events/Transform Game Event"
    )]
    public class TransformGameEvent : BaseGameEvent<UnityEngine.Transform>
    {
    }
}
