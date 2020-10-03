using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.Vector3
{
    [AddComponentMenu("Game Events/Vector 3 Game Event Listener")]
    public class Vector3GameEventListener
        : ArgumentGameEventListener<Vector3GameEvent, Vector3Event, UnityEngine.Vector3>
    {
    }
}
