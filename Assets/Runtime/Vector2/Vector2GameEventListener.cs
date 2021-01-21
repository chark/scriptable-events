using UnityEngine;

namespace GameEvents.Vector2
{
    [AddComponentMenu("Game Events/Vector2 Game Event Listener")]
    public class Vector2GameEventListener
        : BaseGameEventListener<Vector2GameEvent, Vector2UnityEvent, UnityEngine.Vector2>
    {
    }
}
