using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private Text _textFPS;
    private string _currentFPS;
    private float _timeDrawUiTextFPS = 1.0f;
    private int _framesRateRerSec;


    void Start()
    {
        StartCoroutine(FPS()); // only for test
    }


    private IEnumerator FPS()
    {
        while (true)
        {
            int lastFrameCount = Time.frameCount;
            float lastTimeChekingFPS = Time.realtimeSinceStartup;

            yield return new WaitForSeconds(_timeDrawUiTextFPS);

            int FPSCounts = Time.frameCount - lastFrameCount;
            float deltaTimeBetwinCheking = Time.realtimeSinceStartup - lastTimeChekingFPS;

            int roundedFPSCount = Mathf.RoundToInt(FPSCounts / deltaTimeBetwinCheking);

            _currentFPS = string.Format("FPS: {0}", roundedFPSCount);
            _textFPS.text = _currentFPS;
        }
    }
}