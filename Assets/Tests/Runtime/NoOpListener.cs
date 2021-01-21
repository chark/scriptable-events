namespace GameEvents.Tests
{
    public class NoOpListener<TArg> : IGameEventListener<TArg>
    {
        public void OnRaised(TArg arg)
        {
        }
    }
}
