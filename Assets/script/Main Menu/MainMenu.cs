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
        GameManager.Instance.emilyMana = 20;
        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
