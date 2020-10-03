using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.Bool
{
    [AddComponentMenu("Game Events/Bool Game Event Listener")]
    public class BoolGameEventListener : ArgumentGameEventListener<BoolGameEvent, BoolEvent, bool>
    {
    }
}
