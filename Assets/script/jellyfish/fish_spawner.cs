using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fish_spawner : MonoBehaviour
{
    public GameObject fishLarge;
    public GameObject fishMedium;
    public GameObject fishSmall;
    private float timer = 0;
    private float smallFishTimer = 0;
    private float mediumFishTimer = 0;
    private float offset = 4.1f;
    private float highestPoint;
    private float lowestPoint;
    private Collider2D[] colliders;

    void Start()
    {
        highestPoint = transform.position.x + offset;
        lowestPoint = transform.position.x - offset;
        colliders = new Collider2D[1]; 
    }

    void Update()
    {
        if (timer < 2)
        {
            timer += Time.deltaTime;
        }
        else
        {
            spawnLarge();
            timer = 0;
        }
        if (smallFishTimer < 3)
        {
            smallFishTimer += Time.deltaTime;
        }
        else
        {
            spawnSmall();
            smallFishTimer = 0;
        }
        if (mediumFishTimer < 5)
        {
            mediumFishTimer += Time.deltaTime;
        }
        else
        {
            spawnMedium();
            mediumFishTimer = 0;
        }
    }

    void spawnLarge()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(fishLarge, spawnPosition, Quaternion.identity);
    }

    void spawnSmall()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(fishSmall, spawnPosition, Quaternion.identity);
    }

    void spawnMedium()
    {
        Vector3 spawnPosition = GetRandomSpawnPosition();
        Instantiate(fishMedium, spawnPosition, Quaternion.identity);
    }

    Vector3 GetRandomSpawnPosition()
    {
        Vector3 spawnPosition;
        do
        {
            spawnPosition = new Vector3(Random.Range(lowestPoint, highestPoint), transform.position.y, 0);
        } while (IsSpawnPositionOccupied(spawnPosition));

        return spawnPosition;
    }

    bool IsSpawnPositionOccupied(Vector3 spawnPosition)
    {
        int numColliders = Physics2D.OverlapCircleNonAlloc(spawnPosition, 0.5f, colliders); 
        return numColliders > 0;
    }
}
