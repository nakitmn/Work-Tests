using System;
using Enemy_Module;
using UI_Module;
using UI_Module.Level_End;
using Zenject;

namespace Player_Module.Controllers
{
    public sealed class PlayerWinController : IInitializable, IDisposable
    {
        private readonly Player _player;
        private readonly EnemySpawner _enemySpawner;
        private readonly EnemyFactory _enemyFactory;
        private readonly WinScreenShower _winScreenShower;

        public PlayerWinController(Player player,EnemySpawner enemySpawner, 
            EnemyFactory enemyFactory, WinScreenShower winScreenShower)
        {
            _player = player;
            _enemySpawner = enemySpawner;
            _enemyFactory = enemyFactory;
            _winScreenShower = winScreenShower;
        }

        void IInitializable.Initialize()
        {
            _enemySpawner.AllSpawned += OnAllSpawned;
        }

        void IDisposable.Dispose()
        {
            _enemySpawner.AllSpawned -= OnAllSpawned;
            
            for (var i = 0; i < _enemyFactory.ActiveEnemies.Count; i++)
            {
                var enemy = _enemyFactory.ActiveEnemies[i];
                enemy.Died -= OnEnemyDied;
            }
        }

        private void OnAllSpawned()
        {
            _enemySpawner.AllSpawned -= OnAllSpawned;

            for (var i = 0; i < _enemyFactory.ActiveEnemies.Count; i++)
            {
                var enemy = _enemyFactory.ActiveEnemies[i];
                enemy.Died += OnEnemyDied;
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            enemy.Died -= OnEnemyDied;
            
            if (_enemyFactory.ActiveEnemies.Count == 0 && _player.HealthComponent.IsDead == false)
            {
                _winScreenShower.Show();
            }
        }
    }
}