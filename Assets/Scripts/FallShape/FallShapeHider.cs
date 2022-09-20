using Zenject;

public class FallShapeAddScoreHider
{
    private PlayerHitController _playerHitController;

    [Inject]
    public FallShapeAddScoreHider(PlayerHitController playerHitControllerArg)
    {
        _playerHitController = playerHitControllerArg;
        Subscribe();
    }

    private void Subscribe()
    {
        _playerHitController.FallShapeHitPlayerEvent += HideFallShape;
    }

    private void HideFallShape(FallShape fallShape)
    {
        if (fallShape.GetKind() != KindFallShape.addScore)
            return;

        fallShape.Deactivate();
    }
}