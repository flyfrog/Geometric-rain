using UnityEngine;

public class MovingAreaView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _movingAreaSpriteRenderer;

    private Vector2 _movingAreaPositionCenter;
    private float _movingAreaWidth;

    private void Awake()
    {
        PreparePositionVariable();
        PrepareWidthVariable();
    }

    private void PreparePositionVariable()
    {
        _movingAreaWidth = _movingAreaSpriteRenderer.bounds.size.x;
    }
    
    private void PrepareWidthVariable()
    {
        _movingAreaPositionCenter = _movingAreaSpriteRenderer.bounds.center;
    }


    public Vector2 GetMovingAreaPositionCenter()
    {
        return _movingAreaPositionCenter;
    }

    public float GetMovingAreaWidth()
    {
        return _movingAreaWidth;
    }
    
    
}