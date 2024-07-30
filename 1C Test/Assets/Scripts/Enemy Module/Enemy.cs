using System;
using Core;
using UnityEngine;

namespace Enemy_Module
{
    public sealed class Enemy : MonoBehaviour
    {
        public event Action<Enemy> Died;

        public Health Health { get; private set; }
        public MoveComponent MoveComponent { get; private set; }
        public float Speed { get; private set; }
        public int Damage { get; private set; }

        public void Construct(float speed, int health,int damage)
        {
            Speed = speed;
            Damage = damage;
            Health = new Health(health);
            MoveComponent = new MoveComponent(transform, Vector3.down, Speed);
        }

        private void Update()
        {
            if (Health.IsDead) return;

            MoveComponent.OnUpdate();
        }

        public void TakeDamage(int damage)
        {
            Health.Substruct(damage);

            if (Health.IsDead)
            {
                Died?.Invoke(this);
            }
        }
    }
}