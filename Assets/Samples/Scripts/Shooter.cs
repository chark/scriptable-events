using GameEvents.Transform;
using UnityEngine;

namespace GameEvents.Samples
{
    [RequireComponent(typeof(Camera))]
    public class Shooter : MonoBehaviour
    {
        [SerializeField]
        private TransformGameEvent shotGameEvent = default;

        [SerializeField]
        private string shootButton = "Fire1";

        private new Camera camera;

        private void Awake()
        {
            camera = GetComponent<Camera>();
        }

        private void Update()
        {
            if (IsShoot())
            {
                Shoot();
            }
        }

        private bool IsShoot()
        {
            return Input.GetButtonDown(shootButton);
        }

        private void Shoot()
        {
            var ray = camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hit))
            {
                shotGameEvent.Raise(hit.transform);
            }
        }
    }
}
