using System;
using UnityEngine;
using UnityEngine.UI;

public class UIStartMenu : MonoBehaviour
{
    [SerializeField] private Transform _menuPanel;
    [SerializeField] private Button _restartButton;

    public event Action OnClickStartGameEvent;

    private void Start()
    {
        _restartButton.onClick.AddListener(OnclickStartGame);
    }

    private void OnclickStartGame()
    {
        OnClickStartGameEvent?.Invoke();
    }
    

    public void HideGameOverPanel()
    {
        _menuPanel.gameObject.SetActive(false);
    }
}