using Input_Module;
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
            if (_player.HealthComponent.IsDead) return;
            
            _player.MoveComponent.MoveDirection = _input.MovementDirection;
            _player.MoveComponent.OnUpdate();
        }
    }
}