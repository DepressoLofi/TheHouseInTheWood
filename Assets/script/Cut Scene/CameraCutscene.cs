using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraCutscene : MonoBehaviour
{
    [SerializeField] private camera_movement cameraMovement;

    private PlayableDirector timeline;


    private void Start()
    {
        cameraMovement = FindObjectOfType<camera_movement>();
        timeline = GetComponent<PlayableDirector>();
        timeline.stopped += OnTimelineStopped;
        cameraMovement.InCutScene(true);

    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        cameraMovement.InCutScene(false);
    }


}
