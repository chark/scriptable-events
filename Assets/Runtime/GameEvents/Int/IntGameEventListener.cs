using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.Int
{
    [AddComponentMenu("Game Events/Int Game Event Listener")]
    public class IntGameEventListener : ArgumentGameEventListener<IntGameEvent, IntEvent, int>
    {
    }
}
