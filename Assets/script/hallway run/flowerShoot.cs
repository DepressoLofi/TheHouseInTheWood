using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerShoot : MonoBehaviour
{
    public Transform shootPoint1;
    public Transform shootPoint2;
    public Transform shootPoint3;
    public GameObject magicPrefab;
    [SerializeField] float delay = 0.2f;

    
    void Start()
    {
        Shoot();
    }

   
    void Shoot()
    {
        Invoke("InstantiateProjectile1", 0f);
        Invoke("InstantiateProjectile2", delay);
        Invoke("InstantiateProjectile3", delay * 2f);
    }

    private void InstantiateProjectile1()
    {
        GameObject magic1 = Instantiate(magicPrefab, shootPoint1.position, shootPoint1.rotation);
    }

    private void InstantiateProjectile2()
    {
        Instantiate(magicPrefab, shootPoint2.position, shootPoint2.rotation);
    }

    private void InstantiateProjectile3()
    {
        Instantiate(magicPrefab, shootPoint3.position, shootPoint3.rotation);
    }
}