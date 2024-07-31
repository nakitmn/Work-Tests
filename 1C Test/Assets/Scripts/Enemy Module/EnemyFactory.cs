using System.Collections.Generic;
using UnityEngine;

namespace Enemy_Module
{
    public sealed class EnemyFactory
    {
        private readonly List<Enemy> _activeEnemies = new();

        public IReadOnlyList<Enemy> ActiveEnemies => _activeEnemies;

        public Enemy CreateEnemy(EnemyConfig config, Vector3 position, Quaternion rotation, Transform parent = null)
        {
            var speed = Random.Range(config.SpeedRange.x, config.SpeedRange.y);
            var enemy = Object.Instantiate(config.Prefab, position, rotation, parent);

            enemy.Construct(speed, config.Health, config.Damage);
            enemy.Died += Destroy;

            _activeEnemies.Add(enemy);
            return enemy;
        }

        public void Destroy(Enemy enemy)
        {
            enemy.Died -= Destroy;
            _activeEnemies.Remove(enemy);
            Object.Destroy(enemy.gameObject);
        }
    }
}