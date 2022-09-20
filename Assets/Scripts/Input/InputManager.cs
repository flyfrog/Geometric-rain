using System;
using UnityEngine;
using Zenject;

public class InputManager: ITickable
{
    public event Action ClickScreenEvent;
    
    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
            Click();
    }

    private void Click()
    {
        ClickScreenEvent?.Invoke();
    }
}