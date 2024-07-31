using System;
using Core;

namespace UI_Module
{
    public sealed class LoseScreenShower : IDisposable
    {
        private readonly LevelEndScreen _levelEndScreen;

        public LoseScreenShower(LevelEndScreen levelEndScreen)
        {
            _levelEndScreen = levelEndScreen;
        }

        public void Show()
        {
            _levelEndScreen.Show();
            _levelEndScreen.SetTitle("You Lose!");
            _levelEndScreen.NextButtonClicked += OnNextButtonClicked;
        }

        public void Dispose()
        {
            _levelEndScreen.NextButtonClicked -= OnNextButtonClicked;
        }

        private void OnNextButtonClicked()
        {
            _levelEndScreen.NextButtonClicked -= OnNextButtonClicked;
            LevelUtils.Restart();
        }
    }
}