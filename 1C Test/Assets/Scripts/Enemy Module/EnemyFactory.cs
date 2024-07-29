using System.Collections;
using System.ComponentModel;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy_Module
{
    public sealed class EnemyFactory
    {
        private readonly DiContainer _diContainer;

        public EnemyFactory(DiContainer diContainer)
        {
            this._diContainer = diContainer;
        }

        public Enemy CreateEnemy(EnemyConfig config, Vector3 position, Quaternion rotation)
        {
            var enemy = Object.Instantiate(config.Prefab, position, rotation);
            _diContainer.Inject(enemy);

            var speed = Random.Range(config.SpeedRange.x, config.SpeedRange.y);
            enemy.Compose(speed);

            return enemy;
        }
    }
}