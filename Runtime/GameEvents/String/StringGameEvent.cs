using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.String
{
    [CreateAssetMenu(fileName = "StringGameEvent", menuName = "Game Events/String Game Event")]
    public class StringGameEvent : ArgumentGameEvent<string>
    {
    }
}
