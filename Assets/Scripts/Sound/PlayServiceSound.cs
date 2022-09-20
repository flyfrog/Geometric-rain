using UnityEngine;

public class PlayServiceSound
{
    private AudioSource _audioSource;
    private const float _minPitch = 0.7f;
    private const float _maxPitch = 1.3f;

    public  PlayServiceSound(AudioSource audioSourceArg)
    {
        _audioSource = audioSourceArg;
    }

    public void PlayOneShotVariable(AudioClip audioClipArg)
    {
        _audioSource.pitch = Random.Range(_minPitch, _maxPitch);
        _audioSource.PlayOneShot(audioClipArg);
    }
    
    
    public void PlayOneShot(AudioClip audioClipArg)
    {
        _audioSource.PlayOneShot(audioClipArg);
    }
    
 
}