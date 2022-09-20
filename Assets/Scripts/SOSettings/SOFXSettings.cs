using UnityEngine;

[CreateAssetMenu(fileName = "FXSettings", menuName = "GameSO/FXSettingsSettingsSO")]
public class SOFXSettings : ScriptableObject
{
    [Header("Player PS effect")] public ParticleSystem _explosionDeathFXPrefab;

    [Header("Fall shape AddScore PS effect")]
    public AddScoreExplosionFX explosionAddScoreExplosionAddScorehFXPrefab;
}