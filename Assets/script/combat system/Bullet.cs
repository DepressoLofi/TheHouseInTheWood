using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int damageAmount = 2;
    public GameObject hitEffect;
    public float effectDuration = 0.5f;

    public void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Control"))
        {
            IDamageable damageable = other.GetComponent<IDamageable>();
            if (damageable != null)
            {
                damageable.Damage(damageAmount, transform); 
            }
            GameObject effect = Instantiate(hitEffect, transform.position, transform.rotation);
            Destroy(effect, effectDuration);
            Destroy(gameObject);
        }
    }
}
