using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.Vector2
{
    [AddComponentMenu("Game Events/Vector2 Game Event Listener")]
    public class Vector2GameEventListener
        : ArgumentGameEventListener<Vector3GameEvent, Vector2Event, UnityEngine.Vector2>
    {
    }
}
