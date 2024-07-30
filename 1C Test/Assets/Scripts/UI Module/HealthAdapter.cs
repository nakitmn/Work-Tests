using System;
using Assets.Scripts.Core;

namespace Assets.Scripts.UI_Module
{
    public sealed class HealthAdapter : IDisposable
    {
        private readonly Health _health;
        private readonly HealthView _view;

        public HealthAdapter(Health health, HealthView view)
        {
            _health = health;
            _view = view;
        }

        public void Enable()
        {
            _health.HealthChanged += OnHealthChanged;
            OnHealthChanged();
        }

        public void Dispose()
        {
            _health.HealthChanged -= OnHealthChanged;
        }

        private void OnHealthChanged()
        {
            _view.SetHealth($"Health: {_health.Current}");
        }
    }
}