using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIGameOverView : MonoBehaviour
{
    [SerializeField] private Transform _gameOverPanel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private TextMeshProUGUI _scoreText;

    public event Action OnClickRestartButtonEvent;

    private void Start()
    {
        _restartButton.onClick.AddListener(OnclickRestartGameButton);
    }

    private void OnclickRestartGameButton()
    {
        OnClickRestartButtonEvent?.Invoke();
    }


    public void ShowGameOverPanel()
    {
        _gameOverPanel.gameObject.SetActive(true);
    }

    public void SetScoreText(string scoreText)
    {
        _scoreText.text = scoreText;
    }
}