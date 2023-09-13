using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellySpawner : MonoBehaviour
{

    public GameObject Jelly;

    private float timer;
    [SerializeField] private float spawnRate;
    [SerializeField] private bool spawnAtStart;

    private SeaKraken sk;


    // Start is called before the first frame update
    void Start()
    {
        sk = FindAnyObjectByType<SeaKraken>();
        if (spawnAtStart)
        {
            SpawnFish();
        }
       
    }

    // Update is called once per frame
    void Update()
    {
        if (!sk.die)
        {
            if (timer < spawnRate)
            {
                timer += Time.deltaTime;
            }
            else
            {
                SpawnFish();
                timer = 0;
            }
        }
    }

    void SpawnFish()
    {
        Instantiate(Jelly, transform.position, transform.rotation);
    }
}
