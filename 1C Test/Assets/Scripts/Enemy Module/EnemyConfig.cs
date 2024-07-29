using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemy_Module
{
    [CreateAssetMenu(menuName = "Game/Enemy Config")]
    public sealed class EnemyConfig : ScriptableObject
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Vector2 _speedRange;
        [SerializeField] private int _health;

        public Enemy Prefab => _prefab;
        public Vector2 SpeedRange => _speedRange;
        public int Health => _health;
    }
}