using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int emilyHealth;
    public bool fire;
    public bool water;
    public bool nature;
    public bool fireBoss;
    public bool waterBoss;

    private void Awake()
    {
 
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


}
