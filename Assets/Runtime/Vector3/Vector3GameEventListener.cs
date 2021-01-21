using UnityEngine;

namespace GameEvents.Vector3
{
    [AddComponentMenu("Game Events/Vector3 Game Event Listener")]
    public class Vector3GameEventListener
        : BaseGameEventListener<Vector3GameEvent, VectorUnity3Event, UnityEngine.Vector3>
    {
    }
}
