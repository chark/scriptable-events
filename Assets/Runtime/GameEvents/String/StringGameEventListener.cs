using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.String
{
    [AddComponentMenu("Game Events/String Game Event Listener")]
    public class
        StringGameEventListener : ArgumentGameEventListener<StringGameEvent, StringEvent, string>
    {
    }
}
