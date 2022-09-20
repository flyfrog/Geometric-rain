using System;
using Zenject;

public class SpawnerAddScoreFX
{
    public event Action ExplodedFXEvent;
    private PoolAddScoreFX _poolAddScoreFX;
    private PlayerHitController _playerHitController;

    [Inject]
    public SpawnerAddScoreFX(PoolAddScoreFX poolAddScoreFXArg, PlayerHitController playerHitControllerArg)
    {
        _poolAddScoreFX = poolAddScoreFXArg;
        _playerHitController = playerHitControllerArg;
        Subscribe();
    }

    private void Subscribe()
    {
        _playerHitController.FallShapeHitPlayerEvent += SpawnFX;
    }

    private void SpawnFX(FallShape fallShape)
    {
        if (fallShape.GetKind() != KindFallShape.addScore)
            return;

        AddScoreExplosionFX addScoreFX = _poolAddScoreFX.GetFX();
        addScoreFX.gameObject.transform.position = fallShape.GetPosition();

        ExplodedFXEvent?.Invoke();
    }
}