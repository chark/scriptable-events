using GameEvents.Generic;
using UnityEngine;

namespace GameEvents.String
{
    [CreateAssetMenu(fileName = "StringEvent", menuName = "Game Events/String Game Event")]
    public class StringGameEvent : ArgumentGameEvent<string>
    {
    }
}
