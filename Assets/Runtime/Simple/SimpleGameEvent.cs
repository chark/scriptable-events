using UnityEngine;

namespace GameEvents.Simple
{
    [CreateAssetMenu(fileName = "SimpleGameEvent", menuName = "Game Events/Simple Game Event")]
    public class SimpleGameEvent : BaseGameEvent<SimpleArg>
    {
        /// <summary>
        /// Raise this game event without an argument.
        /// </summary>
        public void Raise()
        {
            Raise(SimpleArg.Instance);
        }
    }
}
