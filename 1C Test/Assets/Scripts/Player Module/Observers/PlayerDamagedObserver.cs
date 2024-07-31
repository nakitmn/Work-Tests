using System;
using Camera_Module;
using Zenject;

namespace Player_Module.Observers
{
    public sealed class PlayerDamagedObserver : IInitializable, IDisposable
    {
        private readonly Player _player;
        private readonly CameraShaker _cameraShaker;

        public PlayerDamagedObserver(Player player, CameraShaker cameraShaker)
        {
            _player = player;
            _cameraShaker = cameraShaker;
        }

        void IInitializable.Initialize()
        {
            _player.Damaged += OnDamaged;
        }

        void IDisposable.Dispose()
        {
            _player.Damaged -= OnDamaged;
        }

        private void OnDamaged(Player player)
        {
            _cameraShaker.Play();
        }
    }
}