using System;
using Core;
using Enemy_Module;
using UnityEngine;

namespace Bullet_Module
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet> Collided;

        [SerializeField] private int _damage = 1;
        [SerializeField] private float _speed;
        [SerializeField] private EnemySensor _enemySensor;
        [SerializeField] private GameObject _hitEffect;
        
        private MoveComponent _moveComponent;

        private void Awake()
        {
            _moveComponent = new MoveComponent(transform, _speed);
        }

        private void OnEnable()
        {
            _enemySensor.StateChanged += OnStateChanged;
        }

        private void Update()
        {
            _moveComponent.MoveDirection = transform.TransformDirection(Vector3.up);
            _moveComponent.OnUpdate();
        }

        private void OnDisable()
        {
            _enemySensor.StateChanged -= OnStateChanged;
        }

        private void OnStateChanged()
        {
            var enemy = _enemySensor.GetNearest(transform.position);

            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }

            Instantiate(_hitEffect, transform.position, Quaternion.identity);
            Collided?.Invoke(this);
        }
    }
}