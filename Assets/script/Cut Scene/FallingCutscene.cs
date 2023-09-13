using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class FallingCutscene : MonoBehaviour
{
    [SerializeField] private camera_movement cameraMovement;
    private PlayableDirector timeline;
    

    private void Start()
    {
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
        StartCoroutine(LoadLevel("office 1"));
    }

    IEnumerator LoadLevel(string sceneToLoad)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(sceneToLoad);
    }
}
