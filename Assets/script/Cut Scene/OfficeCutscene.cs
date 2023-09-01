using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class OfficeCutscene : MonoBehaviour
{

    private PlayableDirector timeline;

    public Animator transition;
    private Animator animator;
    public Vector2 facingCut;


    public Vector2 playerPosition;


    public Vector2 facing;
    public VectorValue playerStorage;

    private BackgroundMusicManager musicManager;




    private void Start()
    {
        animator = GameObject.FindGameObjectWithTag("Emily").GetComponent<Animator>();
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

        StartCoroutine(LoadLevel("office", "Black"));
    }

    IEnumerator LoadLevel(string sceneToLoad, string color)
    {
        animator.SetFloat("horizontal", facingCut.x);
        animator.SetFloat("vertical", facingCut.y);
 
        transition.SetTrigger(color);
        musicManager.FadeOutMusic();
        yield return new WaitForSeconds(1f);
        playerStorage.initialValue = playerPosition;
        playerStorage.facing = facing;


        SceneManager.LoadScene(sceneToLoad);
    }




}
