using UnityEngine;
using Zenject;

namespace Bullet_Module
{
    public sealed class BulletFactory
    {
        private readonly BulletPool _bulletPool;

        public BulletFactory(BulletPool bulletPool)
        {
            _bulletPool = bulletPool;
        }

        public Bullet CreateBullet(Vector3 position, Quaternion rotation)
        {
            var bullet = _bulletPool.Spawn();
            bullet.transform.position = position;
            bullet.transform.rotation = rotation;
            
            bullet.Collided += OnBulletCollided;
            return bullet;
        }

        private void OnBulletCollided(Bullet bullet)
        {
            bullet.Collided -= OnBulletCollided;
            _bulletPool.Despawn(bullet);
        }
    }
}