using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy_Module
{
    public sealed class EnemyFactory
    {
        private readonly DiContainer _diContainer;
        private readonly List<Enemy> _activeEnemies = new();

        public IReadOnlyList<Enemy> ActiveEnemies => _activeEnemies;

        public EnemyFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public Enemy CreateEnemy(EnemyConfig config, Vector3 position, Quaternion rotation)
        {
            var enemy = Object.Instantiate(config.Prefab, position, rotation);
            _diContainer.Inject(enemy);

            var speed = Random.Range(config.SpeedRange.x, config.SpeedRange.y);
            enemy.Compose(speed, config.Health);

            _activeEnemies.Add(enemy);
            return enemy;
        }

        public void Destroy(Enemy enemy)
        {
            _activeEnemies.Remove(enemy);
            Object.Destroy(enemy.gameObject);
        }
    }
}