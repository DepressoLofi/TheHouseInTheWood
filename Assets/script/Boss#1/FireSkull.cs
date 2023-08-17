using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkull : MonoBehaviour, IDamageable
{
    float health = 1f;



    private Transform target;
    public float speed = 3.8f;
    public float explosionTriggerRadius = 0.5f;
    public float explosionRadius = 1f;
    public GameObject explosionEffect;
    private Rigidbody2D rb;
    private Player player;


    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Emily").transform;
        player = GameObject.FindGameObjectWithTag("Emily").GetComponent<Player>();

    }

    private void Update()
    {
        if(target != null && !player.die)
        {
            Vector2 direction = target.position - transform.position;   
            float distanceToTarget = direction.magnitude;

            if (distanceToTarget < explosionTriggerRadius)
            {
                Explode();
            }
            else
            {
                Vector2 moveDirection = direction.normalized;
                rb.velocity = moveDirection * speed;

                if (moveDirection.x > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1); 
                }
                else if (moveDirection.x < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1); 
                }
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }
    private void Explode()
    {
        GameObject effect =Instantiate(explosionEffect, transform.position, transform.rotation);
        
        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= explosionRadius) {
            Player playerHealth = target.GetComponent<Player>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(4);
            }
        
        }

        Destroy(effect, 0.5f);
        Destroy(gameObject);
        
    }
    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;

        if (health <= 0)
        {
            Explode();
        }
    }

    public void Damage(float amount)
    {
        TakeDamage(amount);
        
    }
}
