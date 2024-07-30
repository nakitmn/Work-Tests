using UnityEngine;

namespace Enemy_Module
{
    [CreateAssetMenu(menuName = "Game/Enemy Config")]
    public sealed class EnemyConfig : ScriptableObject
    {
        [SerializeField] private Enemy _prefab;
        [SerializeField] private Vector2 _speedRange;
        [SerializeField] private int _health;
        [SerializeField] private int _damage;

        public Enemy Prefab => _prefab;
        public Vector2 SpeedRange => _speedRange;
        public int Health => _health;
        public int Damage => _damage;
    }
}