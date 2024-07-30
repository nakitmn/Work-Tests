using System;
using UI_Module;
using Zenject;

namespace Player_Module.Controllers
{
    public sealed class PlayerLoseController : IInitializable, IDisposable
    {
        private readonly Player _player;
        private readonly LevelEndScreen _levelEndScreen;

        public PlayerLoseController(Player player, LevelEndScreen levelEndScreen)
        {
            _player = player;
            _levelEndScreen = levelEndScreen;
        }

        void IInitializable.Initialize()
        {
            _player.Died += OnDied;
        }

        void IDisposable.Dispose()
        {
            _player.Died -= OnDied;
        }

        private void OnDied(Player player)
        {
            _levelEndScreen.Show();
            _levelEndScreen.SetTitle("You Lose!");
        }
    }
}