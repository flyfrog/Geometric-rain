using System;
using UnityEngine;
using Zenject;

public class PlayerHitController
{
    private PlayerView _playerView;

    public event Action<FallShape> FallShapeHitPlayerEvent;


    [Inject]
    public PlayerHitController(PlayerView playerViewArg)
    {
        _playerView = playerViewArg;
        Subscribe();
    }

    private void Subscribe()
    {
        _playerView.CollisionEnteredEvent += CheckPlayerHit;
    }

    private void CheckPlayerHit(Collision2D collision2D)
    {
        collision2D.gameObject.TryGetComponent(out FallShape fallshape);
        if (fallshape)
        {
            CheckHit(fallshape);
        }
    }


    private void CheckHit(FallShape fallShape)
    {
        FallShapeHitPlayerEvent?.Invoke(fallShape);
    }
}