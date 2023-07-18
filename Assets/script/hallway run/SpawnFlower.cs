using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFlower : MonoBehaviour
{

    public GameObject enemyPrefab;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            Spawn();
        }
            
      
    }

    private void Spawn()
    {
        Instantiate(enemyPrefab, transform.position, transform.rotation);
    }

}
