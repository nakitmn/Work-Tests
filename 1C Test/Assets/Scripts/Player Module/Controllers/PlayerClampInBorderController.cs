using Border_Module;
using UnityEngine;
using Zenject;

namespace Player_Module.Controllers
{
    public sealed class PlayerClampInBorderController : ITickable
    {
        private readonly Player _player;
        private readonly Border _border;

        public PlayerClampInBorderController(Player player, Border border)
        {
            _player = player;
            _border = border;
        }

        void ITickable.Tick()
        {
            Vector3 currentPosition = _player.MoveTransform.position;
            _player.MoveTransform.position = _border.Clamp(currentPosition, _player.HalfSize);
        }
    }
}