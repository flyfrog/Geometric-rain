using UnityEngine;

[CreateAssetMenu(fileName = "SpawnSettings", menuName = "GameSO/SpawnSettingsSO")]
public class SOSpawnSettings : ScriptableObject
{
    
    [Header("Spawn")]
    public float respaunTimeFreqFrequency = 1f;
    public float forcePushForSpawnShape = 2f;
    public float maxSpeenSpeed = 10f;
    
    [Header("Color")]
    public Color _colorKillerShape;
    public Color _colorAddScoreShape;
 
    [Header("Random spawn chance")]
    public float _chanceOfOccurrenceScoreUpKind  = 30f;
    
}