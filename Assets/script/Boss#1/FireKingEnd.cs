using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class FireKingEnd : MonoBehaviour
{
    [SerializeField] private camera_movement cameraMovement;
    private PlayableDirector timeline;
    public Vector2 playerPosition;
    public Vector2 facing;
    public VectorValue playerStorage;
    public Animator transition;



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
        
        StartCoroutine(LoadLevel("office"));
    }

    IEnumerator LoadLevel(string sceneToLoad)
    {
        transition.SetTrigger("Black");
        yield return new WaitForSeconds(1);
        playerStorage.initialValue = playerPosition;
        playerStorage.facing = facing;
        
        SceneManager.LoadScene(sceneToLoad);
    }
}
