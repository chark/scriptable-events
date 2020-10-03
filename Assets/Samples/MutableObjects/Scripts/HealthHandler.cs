using MutableObjects.Int;
using UnityEngine;

namespace MutableObjects
{
    public abstract class HealthHandler : MonoBehaviour
    {
        [SerializeField]
        protected MutableInt health = default;

        public abstract void HandleShot();
    }
}
