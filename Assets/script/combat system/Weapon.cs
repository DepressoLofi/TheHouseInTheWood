using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Weapon : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    private float shootingCooldown = 0.3f;
    private float shootTimer = 0f;

    public float maxBulletDistance = 30f;

    private void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

        Vector2 direction = new Vector2(mousePosition.x - transform.position.x, mousePosition.y - transform.position.y);

        transform.up = direction;

    
        if (Input.GetMouseButtonDown(0) && Time.time >= shootTimer)
        {
            Shoot();
            shootTimer = Time.time + shootingCooldown; 
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Quaternion bulletRotation = firePoint.rotation * Quaternion.Euler(0, 0, 90);

        bullet.transform.rotation = bulletRotation;
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);

        Destroy(bullet, maxBulletDistance / bulletForce);
    }
}
