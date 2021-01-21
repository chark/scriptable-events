using UnityEngine;

namespace GameEvents.String
{
    [AddComponentMenu("Game Events/String Game Event Listener")]
    public class StringGameEventListener
        : BaseGameEventListener<StringGameEvent, StringUnityEvent, string>
    {
    }
}
