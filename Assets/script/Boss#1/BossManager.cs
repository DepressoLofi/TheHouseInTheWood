using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BossManager : MonoBehaviour
{
    public static BossManager instance;

    public int totalFireSkull;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

    }

    private void CountFireSkull()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        totalFireSkull = enemies.Length;
    }

    private void Update()
    {
        CountFireSkull();
    }



}
