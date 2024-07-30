using System;
using Core;
using UnityEngine;

namespace Bullet_Module.Effects
{
    public sealed class HitEffect : MonoBehaviour
    {
        public event Action<HitEffect> Completed;

        [SerializeField] private AnimatorDispatcher _animatorDispatcher;

        private void OnEnable()
        {
            _animatorDispatcher.EventRaised += OnEventRaised;
        }

        private void OnDisable()
        {
            _animatorDispatcher.EventRaised -= OnEventRaised;
        }

        private void OnEventRaised(string key)
        {
            if (key == "Ended")
            {
                Completed?.Invoke(this);
            }
        }
    }
}