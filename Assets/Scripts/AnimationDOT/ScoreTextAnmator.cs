using DG.Tweening;
using UnityEngine;
using Zenject;


public class ScoreTextAnmator
{
    private ScoreController _scoreController;
    private UIScoreView _uiScoreView;
    private RectTransform _textScoreRectTransform;

    [Inject]
    public ScoreTextAnmator(ScoreController scoreControllerArg, UIScoreView uiScoreViewArg)
    {
        _scoreController = scoreControllerArg;
        _uiScoreView = uiScoreViewArg;
        _textScoreRectTransform = _uiScoreView.GetScoreTextRectTransform();

        Subscribe();
    }

    private void Subscribe()
    {
        _scoreController.ScoreAdedEvent += RunScoreTextAnimation;
    }

    private void RunScoreTextAnimation()
    {
        Sequence mySequence = DOTween.Sequence();
        // Add a movement tween at the beginning
        mySequence.Append(_textScoreRectTransform.DOScaleY(1.4f, 0.1f));
        mySequence.Append(_textScoreRectTransform.DOScaleY(1f, 0.2f));
    }
}