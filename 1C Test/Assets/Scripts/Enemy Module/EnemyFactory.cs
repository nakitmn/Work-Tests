using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy_Module
{
    public sealed class EnemyFactory
    {
        private readonly List<Enemy> _activeEnemies = new();

        public IReadOnlyList<Enemy> ActiveEnemies => _activeEnemies;

        public Enemy CreateEnemy(EnemyConfig config, Vector3 position, Quaternion rotation)
        {
            var speed = Random.Range(config.SpeedRange.x, config.SpeedRange.y);
            var enemy = Object.Instantiate(config.Prefab, position, rotation);

            enemy.Construct(speed, config.Health);
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