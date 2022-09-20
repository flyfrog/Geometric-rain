using System;
using Zenject;

public class PlayerDeathController
{
    public event Action PlayerStartedDiedEvent;
    public event Action PlayerEndedDiedEvent;
    private PlayerHitController _playerHitController;
    private PlayerView _playerView;
    private const float TIME_DELAY_BEFORE_START_GAMEOVER = 1f;


    [Inject]
    public PlayerDeathController(PlayerHitController playerHitControllerArg, PlayerView playerViewArg)
    {
        _playerHitController = playerHitControllerArg;
        _playerView = playerViewArg;

        Subscribe();
    }

    private void Subscribe()
    {
        _playerHitController.FallShapeHitPlayerEvent += DeathHit;
    }

    private void DeathHit(FallShape fallShapeArg)
    {
        if (fallShapeArg.GetKind() != KindFallShape.killer)
            return;

        PlayerStartedDiedEvent?.Invoke();
        _playerView.Hide();
        DelayerService.Instance.RunItLater(PlayerDied, TIME_DELAY_BEFORE_START_GAMEOVER);
    }

    private void PlayerDied()
    {
        PlayerEndedDiedEvent?.Invoke();
    }
}