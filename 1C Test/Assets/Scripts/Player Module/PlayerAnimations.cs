using UnityEngine;

namespace Player_Module
{
    public sealed class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private FireAnimations _fireAnimations;

        private const string SHOOT_STATE = "Character3_Shoot";
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        public void PlayShot()
        {
            _animator.Play(SHOOT_STATE);
            _fireAnimations.PlayFire();
        }

        public void SetMoving(bool state)
        {
            _animator.SetBool(IsMoving, state);
        }
    }
}