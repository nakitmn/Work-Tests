using Border_Module;
using Player_Module;
using Zenject;

namespace Enemy_Module.Observers
{
    public sealed class EnemyInBorderObserver : ITickable
    {
        private readonly EnemyFactory _factory;
        private readonly Border _border;
        private readonly Player _player;

        public EnemyInBorderObserver(EnemyFactory factory, Border border, Player player)
        {
            _factory = factory;
            _border = border;
            _player = player;
        }

        void ITickable.Tick()
        {
            var enemies = _factory.ActiveEnemies;

            for (int i = 0; i < enemies.Count; i++)
            {
                var enemy = enemies[i];

                if (_border.IsInBorder(enemy.transform.position))
                {
                    _player.TakeDamage(enemy.Damage);
                    _factory.Destroy(enemy);
                }
            }
        }
    }
}