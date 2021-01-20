using UnityEngine;

namespace GameEvents.Empty
{
    [CreateAssetMenu(fileName = "GameEvent", menuName = "Game Events 2/Game Event")]
    public class GameEvent : BaseGameEvent<EmptyArg>
    {
        public void Raise()
        {
            Raise(EmptyArg.Instance);
        }
    }
}
