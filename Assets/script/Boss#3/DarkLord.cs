using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DarkLord : MonoBehaviour, IDamageable
{
    private Collider2D hitBoxCollider;
    private Animator animator;


    //the boss status
    private int maxHealth = 200;
    private int health;
    public BossHealthBar healthBar;

    // the boss movements
    private Transform player;
    Vector2 wayPoint;
    private float speed = 7f;
    private float range = 0.001f;
    private float centerPointX = 0.5f;
    private float radiusX = 11f;
    private float centerPointY = 4f;
    private float radiusY = 2.5f;
    private float counter = 10;




    // the boss movinbg side
    public int realBody;

    // shooting balls
    private Vector3 direction;
    public Transform shootPoint;
    private float timeBtwShot;
    public float startTimeBetweenShot;
    public GameObject firePrefab;
    [SerializeField] private float bulletSpeed;

    void Start()
    {
        hitBoxCollider = GetComponent<Collider2D>();
        animator = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Emily").transform;

        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

   
    void Update()
    {
        FacingDirection();
    }


    /* 
     ############################################################################
    Some logic for the boss
    #############################################################################
    */

    public void FacingDirection()
    {
        if (player.position.x - transform.position.x >= 0.01f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        else if (player.position.x - transform.position.x <= -0.01f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
    }


    public void Shoot()
    {
        direction = (player.position - transform.position).normalized;
        shootPoint.transform.up = direction;


        if (timeBtwShot <= 0)
        {
            GameObject bullet = Instantiate(firePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
            rb2.AddForce(shootPoint.up * bulletSpeed, ForceMode2D.Impulse);
            Destroy(bullet, 40 / bulletSpeed);

            timeBtwShot = startTimeBetweenShot;
        }
        else
        {
            timeBtwShot -= Time.deltaTime;
        }
    }

    public void StartFight()
    {
        animator.SetTrigger("StartFight");
    }




    public void EnableTheCollider()
    {
        hitBoxCollider.enabled = true;

    }

    public void DisableTheCollider()
    {
        hitBoxCollider.enabled = false;
    }

    private void TakeDamage(int amount)
    {
        health -= amount;
        
        if (health <= 0)
        {
            health = 0;
        }
        healthBar.SetHealth(health);


    }

    public void Damage(int amount, Transform bullet)
    {
        TakeDamage(amount);
    }

    /* 
    ###############################################################################
    Random movement of the Dark Souls
    ###############################################################################
     */
    public void RandomMovement()
    {
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, wayPoint) < range)
        {
            SetNewDestination();
        }
        Shoot();
        if (counter < 0)
        {
            counter = 10;
            SettingTheTrigger();
        }
        else
        {
            counter -= Time.deltaTime;
        }
        
    }
    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range((centerPointX - radiusX), (centerPointX + radiusX)), Random.Range((centerPointY - radiusY), (centerPointY + radiusY)));
    }

    void SettingTheTrigger()
    {
        animator.SetTrigger("DisappearOne");
       
    }

    /* 
    ###############################################################################
    two line movement 
    ###############################################################################
    */

    public void ChoosePoint()  // clone needs another code
    {
        if(Random.Range(0,2) == 0)
        {
            transform.position = new Vector3(-11f, 7f, 0f); // up shoot down
            realBody = 0;
            Invoke("TriggerAppear", 0.2f);
        }
        else
        {
            transform.position = new Vector3(12f, -4f, 0); // down shoot up
            realBody = 1;
            Invoke("TriggerAppear", 0.2f);
        }
    }

    void TriggerAppear()
    {

        animator.SetTrigger("AppearOne");
    }

    public void GoingInLine()
    {
        if(realBody == 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(12f, 7, 0), speed * Time.deltaTime);
            Shoot();
            if(transform.position == new Vector3 (12f, 7, 0))
            {
                TriggerDisappearTwo();
            }
        }
        else if(realBody == 1) {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-11f, -4, 0), speed * Time.deltaTime);
            Shoot();
            if (transform.position == new Vector3(-11f, -4, 0))
            {
                TriggerDisappearTwo();
            }
        }
    }

    void TriggerDisappearTwo()
    {

        animator.SetTrigger("DisappearTwo");
    }

    /* 
    ###############################################################################
    Go To The Point 
    ###############################################################################
    */

     public void GoToPoint()
     {
        transform.position = new Vector3(0.5f, 7.55f, 0f); // up shoot down
        Invoke("TriggerAppearTwo", 0.2f);
     }

    public void TriggerAppearTwo()
    {

        animator.SetTrigger("AppearTwo");
    }








}
