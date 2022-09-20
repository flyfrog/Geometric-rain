using System;
using Zenject;
using Random = UnityEngine.Random;

public class RandomKindSetterController
{
    public event Action<FallShape> SetNewKindEvent;
    private float _addScoreKindShapeProbabilityArgSpawn;
    private SpawnerFallShapesController _spawnerFallShapesController;

    [Inject]
    public RandomKindSetterController(SOSpawnSettings soSpawnSettingsArg,
        SpawnerFallShapesController spawnerFallShapesControllerArg)
    {
        _addScoreKindShapeProbabilityArgSpawn = soSpawnSettingsArg._chanceOfOccurrenceScoreUpKind;
        _spawnerFallShapesController = spawnerFallShapesControllerArg;
        _spawnerFallShapesController.SpawnedFallShapeEvent += SetRandomKind;
    }

    private void SetRandomKind(FallShape fallShape)
    {
        fallShape.SetKind(GetRandomKind());
        SetNewKindEvent?.Invoke(fallShape);
    }

    private KindFallShape GetRandomKind()
    {
        float RandomNumForChoceKindFall = Random.Range(0, 100);

        if (RandomNumForChoceKindFall < _addScoreKindShapeProbabilityArgSpawn)
        {
            return KindFallShape.addScore;
        }
        else
        {
            return KindFallShape.killer;
        }
    }
}