using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class FireSpawner : MonoBehaviour
{
    [SerializeField] private float spawnRate = 10f;
    private float timer = 0f;
    [SerializeField] private float delay = 10f;
    [SerializeField] private GameObject fireSkullPrefab;
    private bool startSpawn = false;

   private void Start()
    {
        StartCoroutine(StartSpawningAfterDelay(delay));
        Debug.Log(BossManager.instance.totalFireSkull);
    }

    private IEnumerator StartSpawningAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        startSpawn = true;

    }

    private void Update()
    {
        if (startSpawn && BossManager.instance.totalFireSkull <= 60)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                Spawn();
                timer = 0f;
            }
        } 
        
    }

    private void Spawn()
    {
        Instantiate(fireSkullPrefab, transform.position, transform.rotation);
    }





}