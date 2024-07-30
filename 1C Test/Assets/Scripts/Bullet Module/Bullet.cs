using System;
using Bullet_Module.Effects;
using Core;
using Enemy_Module;
using UnityEngine;
using Zenject;

namespace Bullet_Module
{
    public sealed class Bullet : MonoBehaviour
    {
        public event Action<Bullet> Collided;

        [SerializeField] private int _damage = 1;
        [SerializeField] private float _speed;
        [SerializeField] private EnemySensor _enemySensor;
        
        private MoveComponent _moveComponent;
        private HitEffectPool _hitEffectPool;

        [Inject]
        public void Construct(HitEffectPool hitEffectPool)
        {
            _hitEffectPool = hitEffectPool;
        }
        
        private void Awake()
        {
            _moveComponent = new MoveComponent(transform, _speed);
        }

        private void OnEnable()
        {
            _enemySensor.StateChanged += OnStateChanged;
        }

        private void OnDisable()
        {
            _enemySensor.StateChanged -= OnStateChanged;
        }

        private void Update()
        {
            _moveComponent.MoveDirection = transform.TransformDirection(Vector3.up);
            _moveComponent.OnUpdate();
        }

        private void OnStateChanged()
        {
            var enemy = _enemySensor.GetNearest(transform.position);

            if (enemy != null)
            {
                enemy.TakeDamage(_damage);
            }

            var hitEffect = _hitEffectPool.Spawn();
            hitEffect.transform.position = transform.position;
            hitEffect.transform.rotation = Quaternion.identity;
            
            Collided?.Invoke(this);
        }
    }
}