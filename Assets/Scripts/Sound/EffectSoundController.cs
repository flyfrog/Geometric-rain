using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class EffectSoundController : MonoBehaviour
{
    private AudioSource _effectAudioSourceSource;
    private AudioClip _explosionPlayerClip;
    private AudioClip _explosionAddScoreClip;
    private AudioClip _hitFallShapeClip;


    private PlayerHitController _playerHitController;
    private PlayerDeathController _playerDeathController;
    private SpawnerAddScoreFX _spawnerAddScoreFX;

    [Inject]
    public void Construct(SOSoundSettings soSoundSettingsArg, PlayerHitController playerHitControllerArg,
        PlayerDeathController playerDeathControllerArg, SpawnerAddScoreFX spawnerAddScoreFXArg )
    {
        
        SetSOSettings(soSoundSettingsArg);

        _playerHitController = playerHitControllerArg;
        _playerDeathController = playerDeathControllerArg;
        _spawnerAddScoreFX = spawnerAddScoreFXArg;

        _playerDeathController.PlayerStartedDiedEvent += PlayPlayerExplosion;
        _playerHitController.FallShapeHitPlayerEvent += PlayHitFallShape;
        _spawnerAddScoreFX.ExplodedFXEvent += PlayAddScoreExplosion;
    
    }

    private void SetSOSettings(SOSoundSettings soSoundSettingsArg)
    {
        _explosionPlayerClip = soSoundSettingsArg.playerExplosion;
        _explosionAddScoreClip = soSoundSettingsArg.addScoreExplosion;
        _hitFallShapeClip = soSoundSettingsArg.hitFallShape;

    }

    private void Awake()
    {
        _effectAudioSourceSource = GetComponent<AudioSource>();
    }

    private void PlayPlayerExplosion()
    {
        Play(_explosionPlayerClip);
    }

    private void PlayAddScoreExplosion()
    {
        Play(_explosionAddScoreClip);
    }

    private void PlayHitFallShape(FallShape f)
    {
        Play(_hitFallShapeClip);
    }

   

    private void Play(AudioClip clipArg)
    {
        _effectAudioSourceSource.PlayOneShot(clipArg);
    }
    
}