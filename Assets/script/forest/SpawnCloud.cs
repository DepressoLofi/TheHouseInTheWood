using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class SpawnCloud : MonoBehaviour
{

    public GameObject cloudOne;
    public GameObject cloudTwo;
    public GameObject cloudThree;
    private float spawnRate = 30;
    private float timer = 0;




    void Start()
    {
        SpawnRandomCloud();
    }

    void Update()
    {
        if ( timer < spawnRate)
        {
            timer += Time.deltaTime;
        }
        else
        {
            SpawnRandomCloud();
            timer = 0;
        }
        
    }

    void SpawnRandomCloud()
    {

        int cloudToSpawn = Random.Range(1, 4); 

        switch (cloudToSpawn)
        {
            case 1:
                Instantiate(cloudOne, transform.position, transform.rotation);
                break;
            case 2:
                Instantiate(cloudTwo, transform.position, transform.rotation);
                break;
            case 3:
                Instantiate(cloudThree, transform.position, transform.rotation);
                break;
            default:
                Debug.LogWarning("Invalid cloud number.");
                break;
        }
    }
}