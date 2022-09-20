using UI;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(AudioSource))]
public class UISoundController : MonoBehaviour
{
    private AudioSource _UIAudioSourcSource;
    private PlayServiceSound _playServiceSound;

    private AudioClip _clickClip;
    private AudioClip _openPanelClip;

    private GameOverController _gameOverController;
    private UIStartMenuController _uiStartMenuController;

    [Inject]
    public void Construct(SOSoundSettings soSoundSettingsArg, GameOverController gameOverControllerArg,
        UIStartMenuController uiStartMenuControllerArg)
    {
        _gameOverController = gameOverControllerArg;
        _uiStartMenuController = uiStartMenuControllerArg;
        
        SetSOSettings(soSoundSettingsArg);
        Subscribe();
    }

    private void Subscribe()
    {
        _gameOverController.OnClickEvent += PlayClick;
        _gameOverController.OpenedPanelEvent += PlayOpenPanel;
        _uiStartMenuController.OnClickEvent += PlayClick;
    }

    private void SetSOSettings(SOSoundSettings soSoundSettingsArg)
    {
        _clickClip = soSoundSettingsArg.click;
        _openPanelClip = soSoundSettingsArg.openPanel;
    }

    private void Awake()
    {
        _UIAudioSourcSource = GetComponent<AudioSource>();
        _playServiceSound = new PlayServiceSound(_UIAudioSourcSource);
    }

    private void PlayClick()
    {
        PlaySound(_clickClip);
    }

    private void PlayOpenPanel()
    {
        PlaySound(_openPanelClip);
    }

    private void PlaySound(AudioClip audioClip)
    {
        _playServiceSound.PlayOneShot(audioClip);
    }
}