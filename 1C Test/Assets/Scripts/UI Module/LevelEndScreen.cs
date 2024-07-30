using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace UI_Module
{
    public sealed class LevelEndScreen : MonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private Button _nextButton;

        public event UnityAction NextButtonClicked
        {
            add => _nextButton.onClick.AddListener(value);
            remove => _nextButton.onClick.RemoveListener(value);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        
        public void SetTitle(string title)
        {
            _title.text = title;
        }
    }
}