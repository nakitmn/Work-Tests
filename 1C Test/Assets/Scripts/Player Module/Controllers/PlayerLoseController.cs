using System;
using UI_Module;
using Zenject;

namespace Player_Module.Controllers
{
    public sealed class PlayerLoseController : IInitializable, IDisposable
    {
        private readonly Player _player;
        private readonly LoseScreenShower _loseScreenShower;

        public PlayerLoseController(Player player, LoseScreenShower loseScreenShower)
        {
            _player = player;
            _loseScreenShower = loseScreenShower;
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
            _loseScreenShower.Show();
        }
    }
}