using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy_Module
{
    public sealed class EnemyMoveController
    {
        private readonly Enemy _enemy;
        private readonly float _speed;

        public EnemyMoveController(Enemy enemy,float speed)
        {
            _enemy = enemy;
            _speed = speed;
        }

        public void OnUpdate()
        {
            _enemy.transform.position += Vector3.down * (_speed * Time.deltaTime);
        }
    }
}