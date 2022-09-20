using UnityEngine;
using Zenject;

public class PoolAddScoreFX : MonoBehaviour
{
    [SerializeField] private Transform _poolContainer;

    private const int POOL_COUNT = 5;
    private AddScoreExplosionFX _addScoreExplosionFXPrefab;
    private const bool _autoexpand = true; 
    private Pool<AddScoreExplosionFX> _pool;

    [Inject]
    private void Construct(SOFXSettings sofxSettingsArg)
    {
        _addScoreExplosionFXPrefab = sofxSettingsArg.explosionAddScoreExplosionAddScorehFXPrefab;
        
    }
    
    private void Awake()
    {
        InitPool();
    }

    private void InitPool()
    {
        _pool = new Pool<AddScoreExplosionFX>(_addScoreExplosionFXPrefab, POOL_COUNT, _poolContainer);
        _pool.autoExpand = _autoexpand;
    }


    public AddScoreExplosionFX GetFX()
    {
        return _pool.GetFreeElement();
    }
}
 