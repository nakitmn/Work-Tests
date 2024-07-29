using Assets.Scripts.Border_Module;
using Assets.Scripts.Player_Module;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy_Module
{
    public sealed class EnemyMoveController : ITickable
    {
        private readonly EnemyFactory _factory;
        private readonly Player player;

        public EnemyMoveController(EnemyFactory factory, Player player)
        {
            _factory = factory;
            this.player = player;
        }

        void ITickable.Tick()
        {
            if (player.HealthComponent.IsDead) return;

            var enemies = _factory.ActiveEnemies;

            for (int i = 0; i < enemies.Count; i++)
            {
                var enemy = enemies[i];
                enemy.transform.position += Vector3.down * (enemy.Speed * Time.deltaTime);
            }
        }
    }
}