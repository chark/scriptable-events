using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.Transform
{
    [AddComponentMenu("Game Events/Transform Game Event Listener")]
    public class TransformGameEventListener
        : ArgumentGameEventListener<TransformGameEvent, TransformEvent, UnityEngine.Transform>
    {
    }
}
