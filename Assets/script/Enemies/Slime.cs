using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour, IDamageable
{
    private int health;
    private int maxHealth = 6;
    public float speed = 2.8f;
    public bool die = false;

    private Animator animator;
    private Rigidbody2D rb;
    private Player player;
    private Transform target;

    public SlimeAttack slimeAttack;
    [SerializeField]private float seeDistance;



    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Emily").transform;
        player = GameObject.FindGameObjectWithTag("Emily").GetComponent<Player>();
        animator = GetComponent<Animator>();
        health = maxHealth;

    }

    private void Update()
    {
        if (!die && Vector2.Distance(transform.position, target.position) < seeDistance)
        {
            if (target != null && !player.die && !slimeAttack.stop)
            {
                Vector2 direction = target.position - transform.position;

                Vector2 moveDirection = direction.normalized;
                rb.velocity = moveDirection * speed;

            }
            else
            {
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            rb.velocity = Vector3.zero;
        }
    }


    public void TakeDamage(int damageAmount)
    {
        if (!die)
        {
            health -= damageAmount;

            if (health <= 0)
            {

                animator.SetTrigger("Die");
                die = true;
                StartCoroutine(DestroyAfterAnimation(0.6f));
            }
            else
            {
                animator.SetTrigger("Hit");
            }

        }


    }

    public void Damage(int amount, Transform p)
    {
        TakeDamage(amount);

    }

    private IEnumerator DestroyAfterAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }

}
