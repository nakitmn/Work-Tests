using Assets.Scripts.Border_Module;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy_Module
{
    public sealed class Enemy : MonoBehaviour
    {
        private EnemyMoveController _moveController;
        private EnemyInBorderObserver _inBorderObserver;
        private Border _border;

        [Inject]
        public void Construct(Border border)
        {
            _border = border;
        }

        public void Compose(float speed)
        {
            _moveController = new EnemyMoveController(this, speed);
            _inBorderObserver = new EnemyInBorderObserver(this, _border);
        }

        private void Update()
        {
            _moveController?.OnUpdate();
            _inBorderObserver?.OnUpdate();
        }
    }
}