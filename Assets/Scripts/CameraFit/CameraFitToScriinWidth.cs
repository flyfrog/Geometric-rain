using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFitToScriinWidth : MonoBehaviour
{
  
    [SerializeField] private  float sceneWidth = 10;
    private Camera  _camera;
    
    void Start() {
        _camera = GetComponent<Camera>();
        
        float unitsPerPixel = sceneWidth / Screen.width;

        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;

        _camera.orthographicSize = desiredHalfHeight;
    }

 
}
