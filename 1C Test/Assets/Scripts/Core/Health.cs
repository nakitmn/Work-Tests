using System;
using UnityEngine;

namespace Assets.Scripts.Core
{
    public sealed class Health
    {
        public event Action Died;
        public event Action HealthChanged;

        public int Max { get; }
        public int Current { get; private set; }
        public bool IsDead => Current == 0;

        public Health(int max)
        {
            Max = Current = max;
        }

        public void Substruct(int value)
        {
            if (IsDead) return;

            Current = Mathf.Max(Current - value, 0);

            HealthChanged?.Invoke();
            
            if (IsDead)
            {
                Died?.Invoke();
            }
        }
    }
}