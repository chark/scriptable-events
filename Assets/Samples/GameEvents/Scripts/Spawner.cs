using UnityEngine;

namespace GameEvents
{
    [RequireComponent(typeof(BoxCollider))]
    public class Spawner : MonoBehaviour
    {
        [Min(0)]
        [SerializeField]
        private int spawnedLimit = 10;

        [SerializeField]
        private UnityEngine.GameObject spawnPrefab = default;

        private new BoxCollider collider;
        private int spawned;

        private void Awake()
        {
            collider = GetComponent<BoxCollider>();
        }

        private void Update()
        {
            if (IsSpawn()) Spawn();
        }

        private bool IsSpawn()
        {
            return spawned < spawnedLimit;
        }

        private void Spawn()
        {
            Instantiate(spawnPrefab, GetSpawnPosition(), GetSpawnRotation(), transform);
            spawned++;
        }

        private UnityEngine.Vector3 GetSpawnPosition()
        {
            var colliderBounds = collider.bounds;
            var position = new UnityEngine.Vector3(
                Random.Range(colliderBounds.min.x, colliderBounds.max.x),
                Random.Range(colliderBounds.min.y, colliderBounds.max.y),
                Random.Range(colliderBounds.min.z, colliderBounds.max.z)
            );

            return colliderBounds.ClosestPoint(position);
        }

        private static Quaternion GetSpawnRotation()
        {
            var angles = new UnityEngine.Vector3(
                GetRandomAngle(),
                GetRandomAngle(),
                GetRandomAngle()
            );

            return Quaternion.Euler(angles);
        }

        private static float GetRandomAngle()
        {
            return Random.Range(0f, 360f);
        }

        public void DecreaseSpawned()
        {
            spawned--;
        }
    }
}
