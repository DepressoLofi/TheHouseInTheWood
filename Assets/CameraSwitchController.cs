using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraSwitchController : MonoBehaviour
{
    public Camera mainCamera;
    public PlayableDirector timeline;

    private Camera currentActiveCamera;

    private void Start()
    {
        currentActiveCamera = mainCamera;
    }

    private void Update()
    {
        if (timeline.state == PlayState.Playing && currentActiveCamera != null)
        {
            SwitchCamera(); 
        }
        else if (timeline.state == PlayState.Paused && currentActiveCamera != mainCamera)
        {
            SwitchCamera(); 
        }
    }

    private void SwitchCamera()
    {
        currentActiveCamera.enabled = false; 
        currentActiveCamera = (currentActiveCamera == mainCamera) ? currentActiveCamera : mainCamera;
        currentActiveCamera.enabled = true;  
    }

}
