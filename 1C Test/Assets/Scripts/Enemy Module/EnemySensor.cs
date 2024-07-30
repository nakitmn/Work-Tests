﻿using System;
using System.Collections.Generic;
using UnityEngine;

namespace Enemy_Module
{
    public sealed class EnemySensor : MonoBehaviour
    {
        public event Action StateChanged;
        
        private readonly List<Enemy> _detectedEnemies = new();

        public IReadOnlyList<Enemy> DetectedEnemies => _detectedEnemies;
        public bool HasTargets => _detectedEnemies.Count > 0;

        private void OnDisable()
        {
            _detectedEnemies.Clear();
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                if (_detectedEnemies.Contains(enemy)) return;

                _detectedEnemies.Add(enemy);
                StateChanged?.Invoke();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.TryGetComponent(out Enemy enemy))
            {
                if (_detectedEnemies.Remove(enemy))
                {
                    StateChanged?.Invoke();
                }
            }
        }
    }
}