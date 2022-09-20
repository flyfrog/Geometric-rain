using UnityEngine;

[CreateAssetMenu(fileName = "SoundSettings", menuName = "GameSO/SoundSettingsSO")]
public class SOSoundSettings : ScriptableObject
{

    [Header("Player move")] 
    public AudioClip playerChangeMoveDirection; 
    public AudioClip playerHitBorderMovingArea; 
    
    [Header("Effects")] 
    public AudioClip playerExplosion;
    public AudioClip addScoreExplosion; 
    public AudioClip hitFallShape; 
  
    [Header("UI")] 
    public AudioClip openPanel; 
    public AudioClip click; 


}