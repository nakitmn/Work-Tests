using System;
using Bullet_Module;
using Core;
using Enemy_Module;
using UI_Module;
using UnityEngine;
using Zenject;

namespace Player_Module
{
    public sealed class Player : MonoBehaviour
    {
        public event Action<Player> Died;

        [SerializeField] private Transform _moveTransform;
        [SerializeField] private EnemySensor _enemySensor;
        [SerializeField] private float _size = 1f;
        [SerializeField] private int _health = 3;
        [SerializeField] private float _speed = 2f;

        [Header("Shoot")] [SerializeField] private Transform _aimTransform;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private float _fireRate = 1f;

        private HealthAdapter _healthAdapter;

        public Health HealthComponent { get; private set; }
        public MoveComponent MoveComponent { get; private set; }
        public FireComponent FireComponent { get; private set; }
        public Transform MoveTransform => _moveTransform;

        public float Size => _size;
        public float HalfSize => _size / 2f;

        [Inject]
        public void Construct(HealthView healthView, BulletFactory bulletFactory)
        {
            HealthComponent = new Health(_health);
            MoveComponent = new MoveComponent(_moveTransform, _speed);
            FireComponent = new FireComponent(bulletFactory, _bulletPrefab, _firePoint, _fireRate);

            _healthAdapter = new HealthAdapter(HealthComponent, healthView);
        }

        private void OnEnable()
        {
            _healthAdapter.Enable();
        }

        private void OnDisable()
        {
            _healthAdapter.Dispose();
        }

        private void Update()
        {
            if (HealthComponent.IsDead) return;

            var nearestEnemy = _enemySensor.GetNearest(_moveTransform.position);

            var direction = nearestEnemy == null
                ? Vector3.up
                : (nearestEnemy.transform.position +
                   (nearestEnemy.transform.up * nearestEnemy.Speed * 0.75f)) -
                  _moveTransform.position;
            
            _aimTransform.up = direction.normalized;

            if (nearestEnemy == null) return;

            FireComponent.TryFire(out _);
        }

        public void TakeDamage(int damage)
        {
            HealthComponent.Substruct(damage);

            if (HealthComponent.IsDead)
            {
                Died?.Invoke(this);
            }
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(_moveTransform.position, Vector3.one * _size);
            Gizmos.color = Color.white;
        }
    }
}