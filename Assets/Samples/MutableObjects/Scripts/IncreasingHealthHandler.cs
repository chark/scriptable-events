namespace MutableObjects
{
    public class IncreasingHealthHandler : HealthHandler
    {
        public override void HandleShot()
        {
            health.Value++;
        }
    }
}
