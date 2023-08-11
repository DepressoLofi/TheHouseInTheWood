using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageAmount = 2f;
    public GameObject hitEffect;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        if (other.gameObject.CompareTag("Enemy"))
        {
            if (enemy != null)
            {
                enemy.TakeDamage(damageAmount); 
                GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
                Destroy(effect, 0.5f);
                Destroy(gameObject);
            }        
        }
    }
}
