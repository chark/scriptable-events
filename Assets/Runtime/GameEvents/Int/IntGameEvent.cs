using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.Int
{
    [CreateAssetMenu(fileName = "IntEvent", menuName = "Game Events/Int Event")]
    public class IntGameEvent : ArgumentGameEvent<int>
    {
    }
}
