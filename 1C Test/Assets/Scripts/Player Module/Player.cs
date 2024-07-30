using Assets.Scripts.Core;
using System;
using Assets.Scripts.Bullet_Module;
using Assets.Scripts.UI_Module;
using Enemy_Module;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Player_Module
{
    public sealed class Player : MonoBehaviour
    {
        public event Action<Player> Died;

        [SerializeField] private Transform _moveTransform;
        [SerializeField] private float _speed = 2f;
        [SerializeField] private float _size = 1f;
        [SerializeField] private int _health = 3;
        [SerializeField] private EnemySensor _enemySensor;
        [SerializeField] private Bullet _bulletPrefab;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private float _fireRate = 1f;

        private HealthAdapter _healthAdapter;
        private HealthView _healthView;
        private BulletFactory _bulletFactory;
        private float _reloadTime;

        public MoveComponent MoveComponent { get; private set; }
        public Health HealthComponent { get; private set; }
        public Transform MoveTransform => _moveTransform;
        public float Size => _size;
        public float HalfSize => _size / 2f;

        public float FireDelay => 1f / _fireRate;

        [Inject]
        public void Construct(HealthView healthView, BulletFactory bulletFactory)
        {
            _bulletFactory = bulletFactory;
            _healthView = healthView;

            HealthComponent = new Health(_health);
            MoveComponent = new MoveComponent(_moveTransform, _speed);
            _healthAdapter = new HealthAdapter(HealthComponent, _healthView);
        }

        private void OnEnable()
        {
            _healthAdapter.Enable();
            _reloadTime = FireDelay;
        }

        private void OnDisable()
        {
            _healthAdapter.Dispose();
        }

        private void Update()
        {
            if (HealthComponent.IsDead) return;
            
            MoveComponent.OnUpdate();

            _reloadTime += Time.deltaTime;

            var enemy = _enemySensor.GetNearest(_moveTransform.position);

            if (enemy == null) return;

            if (_reloadTime >= FireDelay)
            {
                var direction = (enemy.transform.position + (enemy.transform.up * enemy.Speed * 0.75f)) -
                                _moveTransform.position;

                var bullet = _bulletFactory.CreateBullet(_bulletPrefab, _firePoint.position, Quaternion.identity);
                bullet.transform.up = direction.normalized;
                _reloadTime = 0f;
            }
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