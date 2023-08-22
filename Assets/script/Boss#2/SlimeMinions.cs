using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMinions : MonoBehaviour, IDamageable
{
    private int health;
    private int maxhealth;
    public float speed = 3.8f;

    private Rigidbody2D rb;
    private Player player;
    private Transform target;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Emily").transform;
        player = GameObject.FindGameObjectWithTag("Emily").GetComponent<Player>();

    }

    private void Update()
    {
        if (target != null && !player.die)
        {
            Vector2 direction = target.position - transform.position;
            float distanceToTarget = direction.magnitude;

            Vector2 moveDirection = direction.normalized;
            rb.velocity = moveDirection * speed;

        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }


    public void TakeDamage(int damageAmount)
    {
        health -= damageAmount;


    }

    public void Damage(int amount, Transform p)
    {
        TakeDamage(amount);

    }

}
