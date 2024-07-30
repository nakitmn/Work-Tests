using Assets.Scripts.Border_Module;
using Assets.Scripts.Player_Module;
using Zenject;

namespace Assets.Scripts.Enemy_Module
{
    public sealed class EnemyInBorderObserver : ITickable
    {
        private readonly EnemyFactory factory;
        private readonly Border border;
        private readonly Player player;

        public EnemyInBorderObserver(EnemyFactory factory, Border border, Player player)
        {
            this.factory = factory;
            this.border = border;
            this.player = player;
        }

        void ITickable.Tick()
        {
            var enemies = factory.ActiveEnemies;

            for (int i = 0; i < enemies.Count; i++)
            {
                var enemy = enemies[i];

                if (border.IsInBorder(enemy.transform.position))
                {
                    player.TakeDamage(1);
                    factory.Destroy(enemy);
                }
            }
        }
    }
}