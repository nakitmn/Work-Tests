using System;

namespace UI_Module.Health
{
    public sealed class HealthAdapter : IDisposable
    {
        private readonly Core.Health _health;
        private readonly HealthView _view;

        public HealthAdapter(Core.Health health, HealthView view)
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