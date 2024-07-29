using Assets.Scripts.Border_Module;
using Assets.Scripts.Core;
using Assets.Scripts.Player_Module;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.Enemy_Module
{
    public sealed class Enemy : MonoBehaviour
    {
        public Health Health { get; private set; }
        public float Speed { get; private set; }
        /*        private Border _border;
                private Player _player;

                [Inject]
                public void Construct(Border border, Player player)
                {
                    _border = border;
                    _player = player;
                }
        */
        public void Compose(float speed, int health)
        {
            Health = new Health(health);
            Speed = speed;
        }
    }
}