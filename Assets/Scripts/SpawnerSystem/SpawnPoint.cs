using UnityEngine;

namespace Scripts.SpawnerSystem
{
    public class SpawnPoint : MonoBehaviour
    {
        [SerializeField] private Enemy _enemyPrefab;

        public void Spawn()
        {
            var enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity, transform);
        }
    }
}