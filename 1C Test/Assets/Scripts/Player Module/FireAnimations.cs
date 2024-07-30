using UnityEngine;

namespace Player_Module
{
    public sealed class FireAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string FIRE_STATE = "Explosion";
        
        public void PlayFire()
        {
            _animator.Play(FIRE_STATE);
        }
    }
}