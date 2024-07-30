using System;
using Enemy_Module;
using UI_Module;
using Zenject;

namespace Player_Module.Controllers
{
    public sealed class PlayerWinController : IInitializable, IDisposable
    {
        private readonly EnemySpawner _enemySpawner;
        private readonly EnemyFactory _enemyFactory;
        private readonly LevelEndScreen _levelEndScreen;

        public PlayerWinController(EnemySpawner enemySpawner, 
            EnemyFactory enemyFactory, LevelEndScreen levelEndScreen)
        {
            _enemySpawner = enemySpawner;
            _enemyFactory = enemyFactory;
            _levelEndScreen = levelEndScreen;
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
            
            if (_enemyFactory.ActiveEnemies.Count == 0)
            {
                _levelEndScreen.Show();
                _levelEndScreen.SetTitle("You Win!");
            }
        }
    }
}