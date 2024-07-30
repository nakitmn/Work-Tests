using UnityEngine;
using Zenject;

namespace Assets.Scripts.Bullet_Module
{
    public sealed class BulletFactory
    {
        private readonly DiContainer _diContainer;

        public BulletFactory(DiContainer diContainer)
        {
            _diContainer = diContainer;
        }

        public Bullet CreateBullet(Bullet prefab, Vector3 position, Quaternion rotation)
        {
            var bullet = _diContainer.InstantiatePrefab(prefab, position, rotation, null)
                .GetComponent<Bullet>();

            bullet.Collided += OnBulletCollided;
            return bullet;
        }

        private void OnBulletCollided(Bullet bullet)
        {
            bullet.Collided -= OnBulletCollided;
            Object.Destroy(bullet.gameObject);
        }
    }
}