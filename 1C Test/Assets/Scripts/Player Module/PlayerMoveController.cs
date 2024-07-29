using Assets.Scripts.Input_Module;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player_Module
{
    public sealed class PlayerMoveController : ITickable
    {
        private readonly Player _player;
        private readonly IPlayerInput _input;

        public PlayerMoveController(Player player, IPlayerInput input)
        {
            _player = player;
            _input = input;
        }

        void ITickable.Tick()
        {
            if (_player.HealthComponent.IsDead) return;

            Vector3 moveDirection = _input.MovementDirection;
            _player.MoveTransform.position += moveDirection * (_player.Speed * Time.deltaTime);
        }
    }
}