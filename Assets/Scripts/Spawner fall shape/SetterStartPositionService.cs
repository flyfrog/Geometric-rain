using UnityEngine;
using Zenject;

public class SetterStartPositionService
{
    private SpawnerFallShapesView _spawnerFallShapesView;
   
    
    [Inject]
    public SetterStartPositionService(SpawnerFallShapesView pawnerFallShapesViewArg)
    {
        _spawnerFallShapesView = pawnerFallShapesViewArg;
    }


    public void SetStartPostionSpawnedFallShape(FallShape fallShape)
    {
        fallShape.gameObject.transform.position = GetPosition();
    }

    private Vector2 GetPosition()
    {
        float leftSpawnBorder = _spawnerFallShapesView.GetLeftXPointOFSpawn();
        float rightXSpawnBorder = _spawnerFallShapesView.GetRightXPointOFSpawn();
        float xSpawnPosition = Random.Range(leftSpawnBorder, rightXSpawnBorder);
        float ySpawnPosition = _spawnerFallShapesView.GetYPointOfSpawn();
        return new Vector2(xSpawnPosition, ySpawnPosition);
    }
}