﻿using System;
using Core;

namespace UI_Module.Level_End
{
    public sealed class WinScreenShower : IDisposable
    {
        private readonly LevelEndScreen _levelEndScreen;

        public WinScreenShower(LevelEndScreen levelEndScreen)
        {
            _levelEndScreen = levelEndScreen;
        }

        public void Show()
        {
            _levelEndScreen.Show();
            _levelEndScreen.SetTitle("You Win!");
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