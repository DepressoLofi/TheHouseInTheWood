using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damageAmount = 2f;
    public GameObject hitEffect;
    public float effectDuration = 0.5f;

    public void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.gameObject.GetComponent<Enemy>();

        if (other.gameObject.CompareTag("Enemy"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(damageAmount); 
                GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
                Destroy(effect, effectDuration);
                Destroy(gameObject);
            }        
        }
    }
}
