using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player_Module
{
    public sealed class Player : MonoBehaviour
    {
        [SerializeField] private Transform _moveTransform;
        [SerializeField] private float _speed = 2f;

        public Transform MoveTransform => _moveTransform;
        public float Speed => _speed;
 
    }
}