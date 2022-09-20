using UnityEngine;

public class FallShape : MonoBehaviour
{
    private KindFallShape _kindFallShape;

    [SerializeField] private float _lifeTime = 5f;
    private float _currentTime;


    private void Update()
    {
        _currentTime += Time.deltaTime;
        LifeTimeCheker();
    }


    private void OnDisable()
    {
        _currentTime = 0f;
    }


    private void LifeTimeCheker()
    {
        if (_currentTime > _lifeTime)
        {
            Deactivate();
        }
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
    }


    public KindFallShape GetKind()
    {
        return _kindFallShape;
    }

    public void SetKind(KindFallShape kindFallShape)
    {
        _kindFallShape = kindFallShape;
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
}