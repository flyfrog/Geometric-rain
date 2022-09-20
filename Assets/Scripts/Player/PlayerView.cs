using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerView : MonoBehaviour
{
    [SerializeField] private SpriteRenderer _mainSprite;
    public event Action<Collision2D> CollisionEnteredEvent;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionEnteredEvent?.Invoke(collision);
    }
    
    public Vector2 GetPosition()
    {
        return transform.position;
    }
    

    public void SetPosition(Vector2 newPosition)
    {
        _rigidbody2D.MovePosition(newPosition);
    }


    public float GetShapeWidth()
    {
       return _mainSprite.bounds.size.x;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

}