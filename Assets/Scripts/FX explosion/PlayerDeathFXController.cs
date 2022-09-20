using UnityEngine;
using Zenject;

public class PlayerDeathFXController
{
    private PlayerView _playerView;
    private ParticleSystem _FXPrefabPlayerExplosion;
    private PlayerDeathController _playerDeathController;


    [Inject]
    public PlayerDeathFXController(SOFXSettings sofxSettingsArg, PlayerView playerViewArg,
        PlayerDeathController playerDeathControllerArg)
    {
        _playerView = playerViewArg;
        _playerDeathController = playerDeathControllerArg;
        Subscribe();
        SetSOSettings(sofxSettingsArg);
    }

    private void Subscribe()
    {
        _playerDeathController.PlayerStartedDiedEvent += SpawnFXPlayerStartedExplosion;
    }

    private void SetSOSettings(SOFXSettings sofxSettingsArg)
    {
        _FXPrefabPlayerExplosion = sofxSettingsArg._explosionDeathFXPrefab;
    }

    public void SpawnFXPlayerStartedExplosion()
    {
        GameObject.Instantiate(_FXPrefabPlayerExplosion, _playerView.GetPosition(), Quaternion.identity);
    }
}