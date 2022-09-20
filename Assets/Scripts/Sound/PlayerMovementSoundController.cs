using UnityEngine;
using Zenject;
 

[RequireComponent(typeof(AudioSource))]
public class PlayerMovementSoundController: MonoBehaviour
{
     private AudioSource _playerMovementAudioSourcSource;

     private AudioClip _hitBorderClip;
     private AudioClip _changeDirectionClip;
     private PlayerMoveController _playerMoveController;
     private PlayServiceSound _playServiceSound;
     
     [Inject]
     public void Construct  (SOSoundSettings soSoundSettingsArg, PlayerMoveController playerMoveControllerArg)
     {
          SetSOSettings(soSoundSettingsArg);

          _playerMoveController = playerMoveControllerArg;
          Subscribe();
     }

     private void Subscribe()
     {
          _playerMoveController.ChangedDirectionMovementEvent += PlayChangeDirectionSound;
          _playerMoveController.HitTheBorderEvent += PlayHitBorderSound;
     }

     private void SetSOSettings(SOSoundSettings soSoundSettingsArg)
     {
          _hitBorderClip = soSoundSettingsArg.playerHitBorderMovingArea;
          _changeDirectionClip = soSoundSettingsArg.playerChangeMoveDirection;
     }

     private void Awake()
     {
          _playerMovementAudioSourcSource = GetComponent<AudioSource>();
          _playServiceSound = new PlayServiceSound(_playerMovementAudioSourcSource);
     }

     private void PlayHitBorderSound()
     {
          PlaySound(_hitBorderClip);
     }

     private void PlayChangeDirectionSound()
     {
          PlaySound(_changeDirectionClip);
     }

     private void PlaySound(AudioClip audioClip)
     {
          _playServiceSound.PlayOneShotVariable(audioClip);
     }
}