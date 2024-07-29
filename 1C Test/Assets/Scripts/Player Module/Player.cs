using Assets.Scripts.Core;
using System;
using UnityEngine;

namespace Assets.Scripts.Player_Module
{
    public sealed class Player : MonoBehaviour
    {
        public event Action<Player> Died;

        [SerializeField] private Transform _moveTransform;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _size = 1f;
        [SerializeField] private int _health = 3;

        public Health HealthComponent { get; private set; }
        public Transform MoveTransform => _moveTransform;
        public float Speed => _speed;
        public float Size => _size;
        public float HalfSize => _size / 2f;

        private void Awake()
        {
            HealthComponent = new Health(_health);
        }

        private void OnEnable()
        {
            HealthComponent.Died += OnDied;
        }

        private void OnDisable()
        {
            HealthComponent.Died -= OnDied;
        }

        public void TakeDamage(int damage)
        {
            HealthComponent.Substruct(damage);
        }

        private void OnDied()
        {
            Debug.Log("Died");
            Died?.Invoke(this);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_moveTransform.position, Vector3.one * _size);
            Gizmos.color = Color.white;
        }
    }
}