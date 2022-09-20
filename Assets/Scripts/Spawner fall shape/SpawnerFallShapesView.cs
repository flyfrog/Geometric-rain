using UnityEngine;


public class SpawnerFallShapesView : MonoBehaviour
{
    [SerializeField] private Transform _transformLeftBorderSpawnArea;
    [SerializeField] private Transform _transformRightBorderSpawnArea;
    [SerializeField] private Transform _transformYPositionSpawnArea;
    
    private float _leftPositionXOfSpawnArea;
    private float _rightPositionXOfSpawnArea;
    private float _yPositionOfSpawn;


    private void Awake()
    {
        _yPositionOfSpawn = _transformYPositionSpawnArea.position.y;
        _leftPositionXOfSpawnArea = _transformLeftBorderSpawnArea.position.x;
        _rightPositionXOfSpawnArea = _transformRightBorderSpawnArea.position.x;
    }

    public float GetLeftXPointOFSpawn()
    {
        return _leftPositionXOfSpawnArea;
    }
    
    public float GetRightXPointOFSpawn()
    {
        return _rightPositionXOfSpawnArea;
    }

    public float GetYPointOfSpawn()
    {
        return _yPositionOfSpawn;
    }

 
    
}