using Bullet_Module;
using UnityEngine;

namespace Core
{
    public sealed class FireComponent
    {
        private readonly BulletFactory _bulletFactory;
        private readonly Bullet _prefab;
        private readonly Transform _firePoint;
        private readonly float _fireRate;

        private float _nextFireTime;

        public float FireDelay => 1f / _fireRate;
        public bool CanFire => Time.time >= _nextFireTime;

        public FireComponent(BulletFactory bulletFactory, Bullet prefab, Transform firePoint, float fireRate)
        {
            _bulletFactory = bulletFactory;
            _prefab = prefab;
            _firePoint = firePoint;
            _fireRate = fireRate;
        }

        public bool TryFire(out Bullet bullet)
        {
            bullet = null;

            if (CanFire == false) return false;

            bullet = _bulletFactory.CreateBullet(_prefab, _firePoint.position, _firePoint.rotation);
            _nextFireTime = Time.time + FireDelay;
            return true;
        }
    }
}