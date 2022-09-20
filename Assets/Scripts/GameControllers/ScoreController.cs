using System;
using Zenject;


public class ScoreController
{
    public event Action ScoreAdedEvent;

    private PlayerHitController _playerHitController;
    private UIScoreView _uiScoreView;
    private int _score;

    [Inject]
    public ScoreController(PlayerHitController playerHitControllerArg, UIScoreView uiScoreViewArg)
    {
        _playerHitController = playerHitControllerArg;
        _uiScoreView = uiScoreViewArg;
        _playerHitController.FallShapeHitPlayerEvent += ScoreAdd;
    }

    private void ScoreAdd(FallShape fallShapeArg)
    {
        if (fallShapeArg.GetKind() != KindFallShape.addScore)
            return;

        _score++;
        _uiScoreView.SetText(_score.ToString());
        ScoreAdedEvent?.Invoke();
    }

    public int GetScore()
    {
        return _score;
    }
}