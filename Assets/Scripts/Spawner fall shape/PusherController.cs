using UnityEngine;
using Zenject;

public class PusherController
{
    private PlayerView _playerView;
    private SpawnerFallShapesController _spawnerFallShapesController;
    private SetterStartPositionService _setterStartPositionService;
    private float _pushForce;
    private float _spinSpeed;


    [Inject]
    public PusherController(PlayerView playerViewArg, SOSpawnSettings soSpawnSettingsArg,
        SpawnerFallShapesController spawnerFallShapesControllerArg,
        SetterStartPositionService setterStartPositionServiceArg
    )
    {
        _playerView = playerViewArg;
        _spawnerFallShapesController = spawnerFallShapesControllerArg;
        Subscribe();
        SetSOSettings(soSpawnSettingsArg);
        _setterStartPositionService = setterStartPositionServiceArg;
    }

    private void Subscribe()
    {
        _spawnerFallShapesController.SpawnedFallShapeEvent += ShotFallShape;
    }

    private void SetSOSettings(SOSpawnSettings soSpawnSettingsArg)
    {
        _pushForce = soSpawnSettingsArg.forcePushForSpawnShape;
        _spinSpeed = soSpawnSettingsArg.maxSpeenSpeed;
    }

    private Vector2 MathPushVector(Vector2 fallShapePositionArg, float pushForceArg)
    {
        Vector2 directionFallShapeMoving = (Vector2)_playerView.GetPosition() - fallShapePositionArg;
        Vector2 directionFallShapeMovingNormalized = directionFallShapeMoving.normalized;
        Vector2 pushVector = directionFallShapeMovingNormalized * pushForceArg;
        return pushVector;
    }


    private void SetPushForce(Rigidbody2D rigidbody2DArg, Vector2 pushVectorArg)
    {
        rigidbody2DArg.AddForce(pushVectorArg, ForceMode2D.Impulse);
    }


    private void SetSpinFallRect(Rigidbody2D rigidbody2DArg, float maxSpinSpeedArg)
    {
        int randomSpinDirection = Random.Range(0, 2);

        if (randomSpinDirection == 1)
            maxSpinSpeedArg *= -1;

        rigidbody2DArg.AddTorque(maxSpinSpeedArg);
    }


    private void ResetPhysicValue(Rigidbody2D rigidbody2DArg)
    {
        rigidbody2DArg.velocity = Vector2.zero;
        rigidbody2DArg.angularVelocity = 0f;
    }


    public void ShotFallShape(FallShape fallShapeArg)
    {
        _setterStartPositionService.SetStartPostionSpawnedFallShape(fallShapeArg);

        fallShapeArg.TryGetComponent(out Rigidbody2D rigidbody2D);
        ResetPhysicValue(rigidbody2D);
        SetSpinFallRect(rigidbody2D, _spinSpeed);

        Vector2 pushVector = MathPushVector(fallShapeArg.GetPosition(), _pushForce);
        SetPushForce(rigidbody2D, pushVector);
    }
}