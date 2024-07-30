using UnityEngine;

namespace Core
{
    public sealed class MoveComponent
    {
        private readonly Transform _moveTransform;

        public Vector3 MoveDirection { get; set; }
        public float Speed { get; set; }
        
        public bool IsMoving => MoveDirection != Vector3.zero;

        public MoveComponent(Transform moveTransform, float speed)
        {
            _moveTransform = moveTransform;
            Speed = speed;
        }

        public MoveComponent(Transform moveTransform, Vector3 moveDirection, float speed)
        {
            _moveTransform = moveTransform;
            MoveDirection = moveDirection;
            Speed = speed;
        }

        public void OnUpdate()
        {
            _moveTransform.position += MoveDirection * (Speed * Time.deltaTime);
        }
    }
}