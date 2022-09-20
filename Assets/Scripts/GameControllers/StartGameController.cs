using Zenject;

public class StartGameController : IInitializable
{
    private PauseController _pauseController;
    private PlayerMoveController _playerMoveController;

    [Inject]
    public StartGameController(PauseController pauseControllerArg, PlayerMoveController playerMoveControllerArg)
    {
        _pauseController = pauseControllerArg;
        _playerMoveController = playerMoveControllerArg;
    }

    public void Initialize()
    {
        GameLoaded();
    }

    private void GameLoaded()
    {
        _pauseController.PauseOn();
    }

    public void StartGame()
    {
        _playerMoveController.UnlockPlayerMoving();
        _pauseController.PauseOff();
    }
}