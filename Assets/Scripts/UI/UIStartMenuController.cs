using System;
using Zenject;

namespace UI
{
    public class UIStartMenuController
    {
        public event Action OnClickEvent;

        private UIStartMenu _uiStartMenu;
        private StartGameController _startGameController;

        [Inject]
        public UIStartMenuController(UIStartMenu uiStartMenuArg, StartGameController startGameControllerArg)
        {
            _uiStartMenu = uiStartMenuArg;
            _startGameController = startGameControllerArg;
            Subscribe();
        }

        private void Subscribe()
        {
            _uiStartMenu.OnClickStartGameEvent += ClickStart;
        }


        private void ClickStart()
        {
            OnClickEvent?.Invoke();
            _uiStartMenu.HideGameOverPanel();
            _startGameController.StartGame();
        }
    }
}