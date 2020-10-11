using GameEvents.Generic;

namespace GameEvents
{
    public class NoOpListener : IGameEventListener
    {
        public void RaiseGameEvent()
        {
        }
    }
}
