using TMPro;
using UnityEngine;

namespace UI_Module.Health
{
    public sealed class HealthView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _healthField;

        public void SetHealth(string health)
        {
            _healthField.text = health;
        }
    }
}