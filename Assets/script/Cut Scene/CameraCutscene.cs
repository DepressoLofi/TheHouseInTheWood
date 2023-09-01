using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CameraCutscene : MonoBehaviour
{
    [SerializeField] private camera_movement cameraMovement;

    private PlayableDirector timeline;
    public Vector2 facing;
   
    private Animator animator;


    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Emily").GetComponent<Animator>();
        cameraMovement = FindObjectOfType<camera_movement>();
        timeline = GetComponent<PlayableDirector>();
        timeline.stopped += OnTimelineStopped;

    }

    private void Update()
    {
        if (timeline.state == PlayState.Playing)
        {
            cameraMovement.InCutScene(true); 
        }
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        cameraMovement.InCutScene(false);
        animator.SetFloat("horizontal", facing.x);
        animator.SetFloat("vertical", facing.y);
    }


}
