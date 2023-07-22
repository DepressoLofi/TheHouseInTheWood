using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    public int sceneIndex;
    public Animator transition;
    public character_movement playerMovement;

    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Emily").GetComponent<character_movement>();
    }

    public void LoadNextLevel()
    {
        StartCoroutine(LoadLevel(sceneIndex));
    }
    IEnumerator LoadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(1);

        SceneManager.LoadScene(levelIndex);
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Emily") && !other.isTrigger)
        {
            playerMovement.SetCanMove(false);
 
            LoadNextLevel();
        }
    }
}
