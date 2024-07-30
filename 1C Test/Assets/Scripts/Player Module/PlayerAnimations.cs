using UnityEngine;

namespace Player_Module
{
    public sealed class PlayerAnimations : MonoBehaviour
    {
        [SerializeField] private Animator _animator;

        private const string SHOOT_STATE = "Character3_Shoot";
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");

        public void PlayShot()
        {
            _animator.Play(SHOOT_STATE);
        }

        public void SetMoving(bool state)
        {
            _animator.SetBool(IsMoving, state);
        }
    }
}