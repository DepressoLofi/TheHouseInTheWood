using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class EndGame : MonoBehaviour
{
    private camera_movement cameraMovement;
    private Camera cam;
    private PlayableDirector timeline;
    public Animator transition;
    private EndingSong song;
    private Transform emily;
    private Vector3 targetCameraPosition;
    private float cameraSpeed = 1f;

    void Start()
    {
        cameraMovement = FindObjectOfType<camera_movement>();
        timeline = GetComponent<PlayableDirector>();

        timeline.stopped += OnTimelineStopped;
        song = GetComponent<EndingSong>();
        emily = GameObject.FindGameObjectWithTag("Emily").transform;
        cam = Camera.main;
        song = GameObject.FindGameObjectWithTag("EndingSong").GetComponent<EndingSong>();
    }


    void Update()
    {
        if (timeline.state == PlayState.Playing)
        {
            cameraMovement.InCutScene(true);
        }
    }

    private void OnTimelineStopped(PlayableDirector director)
    {
        cameraMovement.InCutScene(false);
        song.ContinueMusic();

        StartCoroutine(LoadLevel("End"));
    }

    IEnumerator LoadLevel(string sceneToLoad)
    {
        transition.SetTrigger("Black");
        yield return new WaitForSeconds(1);


        SceneManager.LoadScene(sceneToLoad);
    }

    public void CameraSignal()
    {
        targetCameraPosition = new Vector3(emily.position.x, emily.position.y, -10);
        StartCoroutine(MoveCamera());
    }

    private IEnumerator MoveCamera()
    {
        while (Vector3.Distance(cam.transform.position, targetCameraPosition) > 0.01f)
        {
            cam.transform.position = Vector3.Lerp(cam.transform.position, targetCameraPosition, Time.deltaTime * cameraSpeed);
            yield return null;
        }
    }
}
