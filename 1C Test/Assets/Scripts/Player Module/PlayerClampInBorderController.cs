using Assets.Scripts.Border_Module;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player_Module
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
            var topLeft = _border.TopLeft;
            var bottomRight = _border.BottomRight;

            var currentPosition = _player.MoveTransform.position;
            currentPosition.x = Mathf.Clamp(currentPosition.x, topLeft.x + _player.HalfSize, bottomRight.x - _player.HalfSize);
            currentPosition.y = Mathf.Clamp(currentPosition.y, bottomRight.y + _player.HalfSize, topLeft.y - _player.HalfSize);

            _player.MoveTransform.position = currentPosition;
        }
    }
}