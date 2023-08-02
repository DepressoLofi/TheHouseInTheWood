using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PortalTransition : MonoBehaviour
{
    public string sceneToLoad;
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
    }
    public void LoadNextLevel()
    {
        if (musicFading == true)
        {
            musicManager.FadeOutMusic();
        } if (musicFading == false)
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
