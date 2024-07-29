using Assets.Scripts.Border_Module;
using UnityEngine;

namespace Assets.Scripts.Enemy_Module
{
    public sealed class EnemyInBorderObserver
    {
        private readonly Enemy enemy;
        private readonly Border border;

        public EnemyInBorderObserver(Enemy enemy, Border border)
        {
            this.enemy = enemy;
            this.border = border;
        }

        public void OnUpdate()
        {
            if (border.IsInBorder(enemy.transform.position))
            {
                Object.Destroy(enemy.gameObject);
            }
        }
    }
}