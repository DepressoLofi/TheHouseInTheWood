using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mantis : MonoBehaviour, IDamageable
{

    private int health;
    private int maxHealth = 6;

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;


    [SerializeField] private float seeDistance;
    private Rigidbody2D rb;

    public bool attack = false;

    private Transform target;


    public Transform attackPoint;
    public float attackRange;
    public LayerMask emilyLayer;

    private bool die = false;

    void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        target = GameObject.FindGameObjectWithTag("Emily").transform;
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        originalColor = spriteRenderer.color;

    }


    void Update()
    {
        if (!die)
        {
            if (Vector2.Distance(transform.position, target.position) <= seeDistance)
            {
                animator.SetFloat("Horizontal", (target.position.x - transform.position.x));
                animator.SetFloat("Vertical", (target.position.y - transform.position.y));
                FollowPlayer();
                if (attack == true)
                {
                    attack = false;
                    Attack();
                }
            }
            else
            {
                animator.SetBool("isMoving", false);
                rb.velocity = Vector3.zero;
            }
        }
        else
        {
            animator.SetBool("isMoving", false);
            rb.velocity = Vector3.zero;
        }




    }

    private void FollowPlayer()
    {
        animator.SetBool("isMoving", true);
    }

    public void Attack()
    {
        Collider2D colinfo = Physics2D.OverlapCircle(attackPoint.position, attackRange, emilyLayer);
        if (colinfo != null)
        {
            colinfo.GetComponent<Player>().TakeDamage(3);
        }
    }
    public void AttackTrigger()
    {
        attack = true;
    }



    void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);

    }

    public void TakeDamage(int damageAmount)
    {
        if (!die)
        {
            health -= damageAmount;

            if (health <= 0)
            {

                animator.SetTrigger("die");
                die = true;
                StartCoroutine(DestroyAfterAnimation(0.6f));
            }
            else
            {
                spriteRenderer.color = new Color(1f, 0, 0);


                StartCoroutine(ReturnToOriginalColorAfterDelay(0.1f));
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

    private IEnumerator ReturnToOriginalColorAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        spriteRenderer.color = originalColor;
    }
}
