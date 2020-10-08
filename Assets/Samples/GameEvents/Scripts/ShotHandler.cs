using UnityEngine;
using UnityEngine.Events;

namespace GameEvents
{
    public class ShotHandler : MonoBehaviour
    {
        [SerializeField]
        private UnityEvent onShot = default;

        public void HandleShot(UnityEngine.Transform shot)
        {
            Destroy(shot.parent.gameObject);
            onShot.Invoke();
        }
    }
}
