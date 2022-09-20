using System;
using Zenject;

 
    public class GameOverController
    {
        public event Action OnClickEvent;
        public event Action OpenedPanelEvent;

        private PlayerDeathController _playerDeathController;
        private PauseController _pauseController;
        private RestartController _restartController;
        private UIGameOverView _uiGameOverView;
        private ScoreController _scoreController;


        [Inject]
        public GameOverController(PlayerDeathController playerDeathControllerArg, UIGameOverView uiGameOverViewArg,
            PauseController pauseControllerArg, RestartController restartControllerArg, ScoreController scoreControllerArg)
        {
            _playerDeathController = playerDeathControllerArg;
            _uiGameOverView = uiGameOverViewArg;
            _pauseController = pauseControllerArg;
            _restartController = restartControllerArg;
            _scoreController = scoreControllerArg;
        
            Subscribe();
        }

        private void Subscribe()
        {
            _playerDeathController.PlayerEndedDiedEvent += GameOver; // тут отписать от хит киллера и подписаться на дед контроллер 
            _uiGameOverView.OnClickRestartButtonEvent += OnClickRestart;
        }

        private void GameOver()
        {
            _pauseController.PauseOn();
            OpenGameOverPanel();
            SetScoreText();
        }

        private void SetScoreText()
        {
            int score = _scoreController.GetScore();
            _uiGameOverView.SetScoreText(score.ToString());
        }

        private void OpenGameOverPanel()
        {
            OpenedPanelEvent?.Invoke();
            _uiGameOverView.ShowGameOverPanel();
        }

        private void OnClickRestart()
        {
            OnClickEvent?.Invoke();
            _restartController.RestartScene();
        }
    }
 