using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WizardAi : MonoBehaviour, IDamageable
{
    public float speed;
    public float stoppingDistance;
    public float seeDistance;

    public Transform player;


    private Vector3 direction;
    public Transform shootPoint;
    private float timeBtwShot;
    public float startTimeBetweenShot;
    public GameObject firePrefab;
    [SerializeField] private float bulletSpeed;

    private Animator animator;
    private int health;
    private int maxHealth = 6;
    private bool die = false;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Emily").transform;
        animator = GetComponent<Animator>();
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (!die)
        {
            if (Vector2.Distance(transform.position, player.position) < seeDistance)
            {
                if (player.position.x - transform.position.x >= 0.01f)
                {
                    transform.localScale = new Vector3(-1f, 1f, 1f);
                }
                else if (player.position.x - transform.position.x <= -0.01f)
                {
                    transform.localScale = new Vector3(1f, 1f, 1f);
                }
                if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
                {

                    transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
                }
                else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
                {
                    transform.position = this.transform.position;
                    ShootFire();
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

    void ShootFire()
    {
        direction = (player.transform.position - transform.position).normalized;
        shootPoint.transform.up = direction;


        if (timeBtwShot <= 0)
        {
            GameObject bullet = Instantiate(firePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
            rb2.AddForce(shootPoint.up * bulletSpeed, ForceMode2D.Impulse);
            Destroy(bullet, 20 / bulletSpeed);

            timeBtwShot = startTimeBetweenShot;
        }
        else
        {
            timeBtwShot -= Time.deltaTime;
        }
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
                StartCoroutine(DestroyAfterAnimation(0.39f));
            }
            else
            {
                animator.SetTrigger("hit");
            }
        }

    }

    private IEnumerator DestroyAfterAnimation(float delay)
    {
        yield return new WaitForSeconds(delay);

        Destroy(gameObject);
    }

    public void Damage(int amount, Transform p)
    {
        TakeDamage(amount);

    }

}
