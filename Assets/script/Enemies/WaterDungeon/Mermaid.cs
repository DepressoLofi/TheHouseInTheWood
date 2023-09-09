using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mermaid : MonoBehaviour, IDamageable
{

    public float speed;
    public float stoppingDistance;
    public float seeDistance;


    private Transform player;
    private Animator animator;
    private int health;
    private int maxHealth = 10;

    [SerializeField] private GameObject firePrefab;
    public Transform shootPoint;

    private SpriteRenderer spriteRenderer;
    private Color originalColor;

    private bool die = false;
    public bool stop = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Emily").transform;
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        health = maxHealth;
        originalColor = spriteRenderer.color;
    }


    void Update()
    {
        if (!die)
        {
            if (Vector2.Distance(transform.position, player.position) < seeDistance && !stop)
            {
                if (player.position.x - transform.position.x >= 0.01f)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }
                else if (player.position.x - transform.position.x <= -0.01f)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
                {

                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
                {
                    transform.position = this.transform.position;
                    stop = true;
                    animator.SetTrigger("attack");
                }
            }
            else
            {
                transform.position = this.transform.position;
            }
        }
        else
        {
            transform.position = this.transform.position;
        }

    }

    public void ShootFire()
    {  
            Instantiate(firePrefab, shootPoint.position, shootPoint.rotation);
    }


    public void ContinueFollowing()
    {
        stop = false;
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
