using UnityEngine;

namespace ScriptableEvents.Samples
{
    [RequireComponent(typeof(BoxCollider))]
    public class Spawner : MonoBehaviour
    {
        [Min(0)]
        [SerializeField]
        private int spawnedLimit = 10;

        [SerializeField]
        private UnityEngine.GameObject spawnPrefab = default;

        [Min(1f)]
        [SerializeField]
        private UnityEngine.Vector3 maxRandomScale =
            new UnityEngine.Vector3(1f, 2f, 1f);

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
            var instance = Instantiate(
                spawnPrefab,
                GetSpawnPosition(),
                GetSpawnRotation(),
                transform
            );

            instance.transform.localScale = GetSpawnScale();

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
                0f,
                GetRandomAngle(),
                0f
            );

            return Quaternion.Euler(angles);
        }

        private static float GetRandomAngle()
        {
            return Random.Range(0f, 360f);
        }

        private UnityEngine.Vector3 GetSpawnScale()
        {
            return new UnityEngine.Vector3(
                Random.Range(1f, maxRandomScale.x),
                Random.Range(1f, maxRandomScale.y),
                Random.Range(1f, maxRandomScale.z)
            );
        }

        public void DecreaseSpawned()
        {
            spawned--;
        }
    }
}
