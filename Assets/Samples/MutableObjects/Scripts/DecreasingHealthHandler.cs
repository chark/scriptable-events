namespace MutableObjects
{
    public class DecreasingHealthHandler : HealthHandler
    {
        public override void HandleShot()
        {
            health.Value--;
            if (health.Value <= 0)
            {
                health.Value = 0;
            }
        }
    }
}
