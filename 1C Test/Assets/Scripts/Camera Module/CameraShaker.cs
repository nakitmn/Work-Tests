using System;
using DG.Tweening;
using UnityEngine;

namespace Camera_Module
{
    public sealed class CameraShaker : MonoBehaviour
    {
        [SerializeField] private float _duration;
        [SerializeField] private float _strength;
        [SerializeField] private int _vibrato;
        [SerializeField] private float _randomness;
        [SerializeField] private ShakeRandomnessMode _randomnessMode;

        private Tween _tween;

        public void Play()
        {
            if (_tween.IsActive())
            {
                _tween.Complete();
            }

            _tween = transform.DOShakePosition(_duration, _strength, _vibrato, _randomness,
                    randomnessMode: _randomnessMode)
                .SetLink(gameObject);
        }
    }
}