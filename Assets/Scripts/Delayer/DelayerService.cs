using System;
using System.Collections;
using UnityEngine;


public class DelayerService : MonoBehaviour
{
    public static DelayerService Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void RunItLater(Action funForInvoke, float delayTimeSec)
    {
        StartCoroutine(DelayerRutine(funForInvoke, delayTimeSec));
    }

    private IEnumerator DelayerRutine(Action funForInvoke, float delayTimeSec)
    {
        yield return new WaitForSeconds(delayTimeSec);
        funForInvoke.Invoke();
    }
}