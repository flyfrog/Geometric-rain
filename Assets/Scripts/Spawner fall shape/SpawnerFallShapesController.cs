using System;
using UnityEngine;
using Zenject;

public class SpawnerFallShapesController : ITickable
{
    public event Action<FallShape> SpawnedFallShapeEvent;

    private float _respTime = 1f;
    private float _currentTime;

    private PoolFallShapesController _poolFallShapesController;
    private PauseController _pauseController;


    [Inject]
    public SpawnerFallShapesController(PoolFallShapesController poolFallShapesControllerArg,
        PauseController pauseControllerArg, SOSpawnSettings soSpawnSettingsArg)
    {
        _poolFallShapesController = poolFallShapesControllerArg;
        _pauseController = pauseControllerArg;
        SetSOSettings(soSpawnSettingsArg);
    }

    private void SetSOSettings(SOSpawnSettings soSpawnSettingsArg)
    {
        _respTime = soSpawnSettingsArg.respaunTimeFreqFrequency;
    }


    public void Tick()
    {
        if (_pauseController.GetPauseState())
            return;

        if (CheckSpawnTimeIsNow())
            Spawn();
    }


    private bool CheckSpawnTimeIsNow()
    {
        _currentTime += Time.deltaTime;
        if (_currentTime > _respTime)
        {
            _currentTime = 0;
            return true;
        }

        return false;
    }

    private void Spawn()
    {
        FallShape newFallShape = _poolFallShapesController.GetFallShape();
        SpawnedFallShapeEvent?.Invoke(newFallShape);
    }
}