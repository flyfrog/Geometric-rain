using System;
using UnityEngine;
using Zenject;

public class PlayerMoveController : IInitializable, IFixedTickable
{
    public event Action ChangedDirectionMovementEvent;
    public event Action HitTheBorderEvent;

    private MovingAreaView _movingAreaView;
    private PlayerView _playerView;
    private InputManager _inputManager;
    private PauseController _pauseController;
    private PlayerDeathController _playerDeathController;
    private CalculationMovingLimitService _calculationMovingLimitService = new CalculationMovingLimitService();

    private Vector2 _playerShapePosition;
    private float _playerShapeSpeed = 4f;
    private float _currentXPlayerShapePosition = 0;
    private PlayerMovingDirection _directionMoving = PlayerMovingDirection.moveToLeft;
    private MovingLimit _movingLimit;
    private bool _playerMovingLock = true;


    [Inject]
    public PlayerMoveController(MovingAreaView movingAreaViewArg, PlayerView playerViewArg,
        InputManager inputManagerArg, PauseController pauseControllerArg,
        SOPlayerShapeSettings soPlayerShapeSettingsArg, PlayerDeathController playerDeathControllerArg)
    {
        _movingAreaView = movingAreaViewArg;
        _playerView = playerViewArg;
        _inputManager = inputManagerArg;
        _pauseController = pauseControllerArg;
        _playerDeathController = playerDeathControllerArg;

        SetSOSettings(soPlayerShapeSettingsArg);
        Subscribe();
    }

    private void SetSOSettings(SOPlayerShapeSettings soPlayerShapeSettingsArg)
    {
        _playerShapeSpeed = soPlayerShapeSettingsArg.playerShapeSpeed;
    }

    public void Initialize()
    {
        InitMovingXLimit();
        SetPlayerShapePositionCoordinateCenterMovingArea();
    }

    private void SetPlayerShapePositionCoordinateCenterMovingArea()
    {
        _playerShapePosition = _movingAreaView.GetMovingAreaPositionCenter();
    }

    private void Subscribe()
    {
        _inputManager.ClickScreenEvent += PlayerClickOnScreen;
        _playerDeathController.PlayerStartedDiedEvent += LockPlayerMoving;
    }

    private void InitMovingXLimit()
    {
        Vector2 movingAreaCenterPosition = _movingAreaView.GetMovingAreaPositionCenter();
        float movingAreaWidth = _movingAreaView.GetMovingAreaWidth();
        float playerShapeWidth = _playerView.GetShapeWidth();
        _movingLimit =
            _calculationMovingLimitService.GetLimit(movingAreaCenterPosition, movingAreaWidth, playerShapeWidth);
    }


    public void FixedTick()
    {
        if (_pauseController.GetPauseState())
            return;
        if (_playerMovingLock)
            return;

        MovingPlayerShape();
        SetPlayerShapeNewPosition();
    }

    private void MovingPlayerShape()
    {
        if (_directionMoving == PlayerMovingDirection.moveToRight)
        {
            //move to right
            if (_currentXPlayerShapePosition < _movingLimit.right)
            {
                _currentXPlayerShapePosition += Time.fixedDeltaTime * _playerShapeSpeed;
            }
            else
            {
                _directionMoving = PlayerMovingDirection.atRestRight;
                HitBorder();
            }
        }

        if (_directionMoving == PlayerMovingDirection.moveToLeft)
        {
            //move to left
            if (_currentXPlayerShapePosition > _movingLimit.left)
            {
                _currentXPlayerShapePosition -= Time.fixedDeltaTime * _playerShapeSpeed;
            }
            else
            {
                _directionMoving = PlayerMovingDirection.atRestLeft;
                HitBorder();
            }
        }
    }

    private void HitBorder()
    {
        HitTheBorderEvent?.Invoke();
    }

    private void SetPlayerShapeNewPosition()
    {
        _playerShapePosition.x = _currentXPlayerShapePosition;
        _playerView.SetPosition(_playerShapePosition);
    }

    private void PlayerClickOnScreen()
    {
        if (_playerMovingLock)
            return;

        ChangeDirection();
    }


    private void ChangeDirection()
    {
        ChangedDirectionMovementEvent?.Invoke();

        if (_directionMoving == PlayerMovingDirection.moveToLeft ||
            _directionMoving == PlayerMovingDirection.atRestLeft)
        {
            _directionMoving = PlayerMovingDirection.moveToRight;
            return;
        }

        if (_directionMoving == PlayerMovingDirection.moveToRight ||
            _directionMoving == PlayerMovingDirection.atRestRight)
        {
            _directionMoving = PlayerMovingDirection.moveToLeft;
            return;
        }
    }

    public void LockPlayerMoving()
    {
        _playerMovingLock = true;
    }

    public void UnlockPlayerMoving()
    {
        _playerMovingLock = false;
    }
}