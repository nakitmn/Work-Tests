using Input_Module;
using UnityEngine;
using Zenject;

namespace Player_Module.Controllers
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
            _player.MoveComponent.MoveDirection = _player.HealthComponent.IsDead
                ? Vector3.zero
                : _input.MovementDirection;

            _player.MoveComponent.OnUpdate();
        }
    }
}