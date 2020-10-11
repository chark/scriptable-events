using GameEvents.Generic;

namespace GameEvents
{
    public class NoOpArgumentListener<TArgument> : IArgumentGameEventListener<TArgument>
    {
        public void RaiseGameEvent(TArgument argument)
        {
        }
    }
}
