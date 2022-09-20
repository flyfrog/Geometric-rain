using UnityEngine;

[CreateAssetMenu(fileName = "PoolSettings", menuName = "GameSO/PoolSettingsSO")]
public class SOPoolSettings : ScriptableObject
{
    [Header("Pool")] 
    public FallShape fallShapePrefab;
}