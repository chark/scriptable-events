using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.Vector3
{
    [CreateAssetMenu(fileName = "Vector3GameEvent", menuName = "Game Events/Vector3 Game Event")]
    public class Vector3GameEvent : ArgumentGameEvent<UnityEngine.Vector3>
    {
    }
}
