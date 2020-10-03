using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.Bool
{
    [CreateAssetMenu(fileName = "BoolGameEvent", menuName = "Game Events/Bool Game Event")]
    public class BoolGameEvent : ArgumentGameEvent<bool>
    {
    }
}
