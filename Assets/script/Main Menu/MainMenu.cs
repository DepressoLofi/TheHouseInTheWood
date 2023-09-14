using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements.Experimental;

public class MainMenu : MonoBehaviour
{
    [SerializeField] string level = "office";

    public Vector2 playerPosition;
    public Vector2 facing;
    public VectorValue playerStorage;

 
    public void NewGame()
    {
        playerStorage.initialValue = playerPosition;
        playerStorage.facing = facing;
        GameManager.Instance.emilyHealth = 25;
        GameManager.Instance.fire = false;
        GameManager.Instance.water = false;
        GameManager.Instance.nature = false;
        GameManager.Instance.fireBoss = false;
        GameManager.Instance.waterBoss = false;

        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
