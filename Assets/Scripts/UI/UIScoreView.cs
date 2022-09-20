using TMPro;
using UnityEngine;


public class UIScoreView : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _ScoreText;

    public void SetText(string scoreTextArg)
    {
        _ScoreText.text = scoreTextArg;
    }

    public RectTransform GetScoreTextRectTransform()
    {
        return _ScoreText.gameObject.GetComponent<RectTransform>();
    }
}