using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ConfrontingCutscene : MonoBehaviour
{

    private PlayableDirector timeline;

    public Animator transition;

    public Vector2 facingCut;


    public Vector2 playerPosition;


    public Vector2 facing;
    public VectorValue playerStorage;

    private BackgroundMusicManager musicManager;




    private void Start()
    {

        timeline = GetComponent<PlayableDirector>();
        timeline.stopped += OnTimelineStopped;
        musicManager = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<BackgroundMusicManager>();
        if (musicManager == null)
        {
            musicManager = null;
        }

    }


    private void OnTimelineStopped(PlayableDirector director)
    {

        StartCoroutine(LoadLevel("DarkHallWay", "Black"));
    }

    IEnumerator LoadLevel(string sceneToLoad, string color)
    {


        transition.SetTrigger(color);
        musicManager.FadeOutMusic();
        yield return new WaitForSeconds(1f);
        playerStorage.initialValue = playerPosition;
        playerStorage.facing = facing;


        SceneManager.LoadScene(sceneToLoad);
    }



}
