using UnityEngine;
using Zenject;

public class PoolFallShapesController : MonoBehaviour
{
    [SerializeField] private Transform _poolContainer;

    private const int POOL_COUNT = 10;
    private FallShape _fallShapePrefab;
    private const bool _autoexpand = true;
    private Pool<FallShape> _pool;

    [Inject]
    private void Construct(SOPoolSettings soPoolSettingsArg)
    {
        _fallShapePrefab = soPoolSettingsArg.fallShapePrefab;
    }

    private void Awake()
    {
        InitPool();
    }

    private void InitPool()
    {
        _pool = new Pool<FallShape>(_fallShapePrefab, POOL_COUNT, _poolContainer);
        _pool.autoExpand = _autoexpand;
    }


    public FallShape GetFallShape()
    {
        return _pool.GetFreeElement();
    }
}