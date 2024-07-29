using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player_Module
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private Transform _moveTransform;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _size = 1f;

        public Transform MoveTransform => _moveTransform;
        public float Speed => _speed;
        public float Size => _size;
        public float HalfSize => _size / 2f;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_moveTransform.position, Vector3.one * _size);
            Gizmos.color = Color.white;
        }
    }
}