using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.Transform
{
    [CreateAssetMenu(
        fileName = "TransformGameEvent",
        menuName = "Game Events/Transform Game Event"
    )]
    public class TransformGameEvent : ArgumentGameEvent<UnityEngine.Transform>
    {
    }
}
