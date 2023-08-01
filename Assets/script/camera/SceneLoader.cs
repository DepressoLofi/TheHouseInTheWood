 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public string sceneToLoad;
    public Animator transition;
    private character_movement playerMovement;
    private BackgroundMusicManager musicManager;

    public Vector2 playerPosition;
    public Vector2 facing;
    public VectorValue playerStorage;


    
    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Emily").GetComponent<character_movement>();
        musicManager = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<BackgroundMusicManager>();
    }

    public void LoadNextLevel()
    {
        if (musicManager != null)
        {
            musicManager.FadeOutMusic(); 
        }
        StartCoroutine(LoadLevel(sceneToLoad));
    }
    IEnumerator LoadLevel(string sceneToLoad)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

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
