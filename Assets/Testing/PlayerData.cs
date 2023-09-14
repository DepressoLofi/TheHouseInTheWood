using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData 
{
    public int emilyHealth;
    public bool fire;
    public bool water;
    public bool nature;
    public bool fireBoss;
    public bool waterBoss;
    public float[] position;
    public int sceneIndex;

    public PlayerData (Player player)
    {
        emilyHealth = player.currentHealth;



    }

}
