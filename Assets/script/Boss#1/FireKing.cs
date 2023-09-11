using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireKing : MonoBehaviour, IDamageable
{
    private Rigidbody2D rb;
    public float speed = 1f;

    //boss Status
    private int maxHealth = 125;
    private int health;
    public BossHealthBar healthBar;
    public GameObject SmokeEffect;

    //shooting
    private float timeBtwShot;
    public float startTimeBetweenShot;
    [SerializeField]private float bulletSpeed;
    public Transform shootPoint;
    public GameObject firePrefab;
    private Vector3 direction;

    //The target - Emily
    private GameObject emily;
    private float yOffset = 1f;

    // For PatternOne circular motion
    public Transform centerPosition;
    public float radius = 5f;
    private float angle = 0f;
    

    //For PatternTwo zigzag motion
    public float zigzagSpeed = 15f;
    public Transform pos;
    public Transform pos1;
    public Transform pos2;
    public Transform pos3;
    public Transform pos4;
    public Transform pos5;
    public Transform pos6;

    //For PatternThree Wandering motion
    /*[SerializeField] float wanderingSpeed;
    [SerializeField] float range;
    [SerializeField] float maxDistance;
    Vector2 wayPoint;
    */

    //pattern changing
    private bool circling;
    //private bool wandering;
    //private int counter = 0;

    //colliding with Emily
    private bool canDealDamage = true;
    private float cooldownDuration = 0.5f;
    private float lastDamageTime = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        emily = GameObject.FindGameObjectWithTag("Emily");
        timeBtwShot = startTimeBetweenShot;

        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        

        PatternTwo();
    }



    void Update()
    {

        if(circling == true)
         {
             PatternOne();
         }  
       // PatternThree();
    }

    void ShootFire()
    {
        Vector3 targetPosition = emily.transform.position + new Vector3(0f, yOffset, 0f);
        direction = (targetPosition - transform.position).normalized;
        shootPoint.transform.up = direction;


        if (timeBtwShot <= 0)
        {
            GameObject bullet = Instantiate(firePrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rb2 = bullet.GetComponent<Rigidbody2D>();
            rb2.AddForce(shootPoint.up * bulletSpeed, ForceMode2D.Impulse);
            Destroy(bullet,  20/ bulletSpeed);

            timeBtwShot = startTimeBetweenShot;
        }
        else
        {
            timeBtwShot -= Time.deltaTime;
        }
    }


    void PatternOne()
    {

        Vector3 newPosition = centerPosition.position + new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius;

        rb.MovePosition(newPosition);
        ShootFire();

        angle += speed * Time.deltaTime;
        if (angle > 360)
        {
            angle -= 360;
            //circling = false;

        }
    }

    void PatternTwo()
    {
        circling = false;
        //wandering = true;
        StartCoroutine(MoveBetweenPositions());
    }

    /*void PatternThree()
    {
        if (Vector2.Distance(transform.position, wayPoint) < range) 
        {
            SetNewDestination();
            counter += 1;
        } 
       
        transform.position = Vector2.MoveTowards(transform.position, wayPoint, wanderingSpeed * Time.deltaTime);
        ShootFire();

        if (counter> 7)
        {
            wandering = false;
            transform.position = Vector2.MoveTowards(transform.position, centerPosition.position + new Vector3(Mathf.Sin(angle), Mathf.Cos(angle), 0) * radius, );
        }
    


    }*/

    IEnumerator MoveBetweenPositions()
    {
        Transform[] positions = { pos1, pos2, pos3, pos4, pos5, pos6 };

        for (int i = 0; i < positions.Length; i++)
        {
            Vector3 startPosition = transform.position;
            Vector3 targetPosition = positions[i].position;
            float distance = Vector3.Distance(startPosition, targetPosition);
            float journeyDuration = distance / zigzagSpeed;

            float startTime = Time.time;
            float journeyFraction = 0f;

            while (journeyFraction < 1f)
            {
                float currentTime = Time.time - startTime;
                journeyFraction = currentTime / journeyDuration;

                transform.position = Vector3.Lerp(startPosition, targetPosition, journeyFraction);
                yield return null;
            }
        }

  
        Vector3 startPos = transform.position;
        Vector3 targetPos = pos.position;
        float dist = Vector3.Distance(startPos, targetPos);
        float duration = dist / zigzagSpeed;

        float startTimestamp = Time.time;
        float fraction = 0f;

        while (fraction < 1f)
        {
            float elapsed = Time.time - startTimestamp;
            fraction = elapsed / duration;

            transform.position = Vector3.Lerp(startPos, targetPos, fraction);
            yield return null;
        }

        circling = true;
    }

    /*void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));
    }*/


    private void TakeDamage(int amount, Transform bullet)
    {
        health -= amount;
        
        GameObject effect = Instantiate(SmokeEffect, bullet.position, bullet.rotation);
        Destroy(effect, 0.5f);

        if (health <= 0) { 
            health = 0;
            Debug.Log("boss died");
        }
        healthBar.SetHealth(health);


    }

    public void Damage(int amount, Transform bullet)
    {
        TakeDamage(amount, bullet);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (canDealDamage && Time.time - lastDamageTime >= cooldownDuration)
        {
            if (other.gameObject.CompareTag("Emily"))
            {
                Player emily = other.gameObject.GetComponent<Player>();
                emily.TakeDamage(5);

                lastDamageTime = Time.time;
                canDealDamage = false;
                StartCoroutine(ResetCooldown());
            }
        }
    }

    private System.Collections.IEnumerator ResetCooldown()
    {
        yield return new WaitForSeconds(cooldownDuration);
        canDealDamage = true;
    }
}
