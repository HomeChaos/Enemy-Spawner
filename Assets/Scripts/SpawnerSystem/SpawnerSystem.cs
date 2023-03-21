using System.Collections;
using UnityEngine;

namespace Scripts.SpawnerSystem
{
    public class SpawnerSystem : MonoBehaviour
    {
        [Tooltip("in secconds")][SerializeField] private float _timeToSpawn = 2f;

        private SpawnPoint[] _points;
        private int _currentPoint = 0;

        private void Start()
        {
            _points = GetComponentsInChildren<SpawnPoint>();
            StartCoroutine(StartSpawn());
        }

        private IEnumerator StartSpawn()
        {
            var isSpawnerWork = true;
            var waitForSecond = new WaitForSeconds(_timeToSpawn);

            while (isSpawnerWork)
            {
                _points[_currentPoint].Spawn();
                _currentPoint++;
                
                if (_currentPoint >= _points.Length)
                {
                    _currentPoint = 0;
                }

                yield return waitForSecond;
            }
        }
    }
}