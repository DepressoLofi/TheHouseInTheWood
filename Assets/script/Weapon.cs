using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Weapon : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireForce;

    public void Fire(Vector2 fireDirection)
    {
        GameObject projectile = Instantiate(bullet, firePoint.position, Quaternion.identity);
        projectile.transform.right = fireDirection;
        projectile.GetComponent<Rigidbody2D>().AddForce(fireDirection * fireForce, ForceMode2D.Impulse);
    }
}
