using GameEngine.Primitives.Containers;
using GameEngine.Primitives.Events;
using UnityEngine;

namespace GameEngine.Mechanics
{
    public class SpawnBulletMechanics : MonoBehaviour
    {
        [SerializeField]
        private GameObject bulletPrefab;
        
        [SerializeField] 
        private Vector3EventReceiver spawnEventReceiver;

        [SerializeField] 
        private TransformBehaviour spawnTransform;

        [SerializeField] 
        private FloatBehaviour bulletSpeed;
        private void OnEnable()
        {
            this.spawnEventReceiver.OnEvent += OnSpawnRequested;
        }

        private void OnDisable()
        {
            this.spawnEventReceiver.OnEvent -= OnSpawnRequested;
        }

        private void OnSpawnRequested(Vector3 direction)
        {
            // dummy bullet spawn and fly by velocity
            var bullet = Instantiate(bulletPrefab, spawnTransform.Value.position, Quaternion.identity);
            bullet.SetActive(true);
            bullet.GetComponent<Rigidbody>().velocity = direction.normalized * bulletSpeed.Value;
        }

    }
}