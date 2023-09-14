using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ToTheEntrance : MonoBehaviour
{
    private string sceneToLoad;
    private character_movement playerMovement;
    private BackgroundMusicManager musicManager;

    [SerializeField] private float waitSecond = 1f;
    [SerializeField] private string color = "Black";
    [SerializeField] private bool musicFading = true;
    public Animator transition;


    public Vector2 playerPosition;


    public Vector2 facing;
    public VectorValue playerStorage;

    void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Emily").GetComponent<character_movement>();
        musicManager = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<BackgroundMusicManager>();
        if (musicManager == null)
        {
            musicManager = null;
        }
        if(!GameManager.Instance.fireBoss && !GameManager.Instance.waterBoss)
        {
            sceneToLoad = "entrance";
        } else if (GameManager.Instance.fireBoss && !GameManager.Instance.waterBoss)
        {
            sceneToLoad = "entrance 1";
        }else if(GameManager.Instance.fireBoss && GameManager.Instance.waterBoss)
        {
            sceneToLoad = "entrance 3";
        }else
        {
            sceneToLoad = "entrance 2";
        }


    }
    public void LoadNextLevel()
    {
        if (musicFading == true)
        {
            musicManager.FadeOutMusic();
        }
        if (musicFading == false)
        {
            musicManager.ContinueMusic();
        }
        StartCoroutine(LoadLevel(sceneToLoad, color));
    }

    IEnumerator LoadLevel(string sceneToLoad, string color)
    {
        transition.SetTrigger(color);

        yield return new WaitForSeconds(waitSecond);

        SceneManager.LoadScene(sceneToLoad);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Emily") && !other.isTrigger)
        {
            playerMovement.SetTransition(true);

            playerStorage.initialValue = playerPosition;
            playerStorage.facing = facing;

            LoadNextLevel();

        }
    }


}
