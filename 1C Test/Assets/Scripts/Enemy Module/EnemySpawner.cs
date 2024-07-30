using System.Collections;
using UnityEngine;
using Zenject;

namespace Enemy_Module
{
    public sealed class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyConfig _enemyConfig;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField] private Vector2Int _spawnCount;
        [SerializeField] private Vector2 _spawnDelay;

        private EnemyFactory _factory;

        [Inject]
        public void Construct(EnemyFactory factory)
        {
            _factory = factory;
        }

        private void Start()
        {
            StartCoroutine(SpawnRoutine());
        }

        private IEnumerator SpawnRoutine()
        {
            int spawnCount = Random.Range(_spawnCount.x, _spawnCount.y + 1);

            for (int i = 0; i < spawnCount; i++)
            {
                var point = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
                _factory.CreateEnemy(_enemyConfig, point.position, point.rotation);
                var delay = Random.Range(_spawnDelay.x, _spawnDelay.y);
                yield return new WaitForSeconds(delay);
            }
        }
    }
}