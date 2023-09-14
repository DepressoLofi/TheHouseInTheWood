using UnityEngine;


public class SeaKraken : MonoBehaviour, IDamageable
{
    //Kraken status
    private int maxHealth = 130;
    private int health;
    public BossHealthBar healthBar;
    private int hitCount;

    //Kraken movement
    [SerializeField] float speed;
    [SerializeField] float range;
    [SerializeField] float maxDistance;

    Vector2 wayPoint;

    //Kraken Shoot
    private float timeBtwShot;
    public float startTimeBetweenShot;
    [SerializeField] private float bulletSpeed;
    public Transform shootPoint;
    public GameObject firePrefab;
    private Vector3 direction;

    //The target - Emily
    private GameObject emily;

    //colliding with Emily
    private bool canDealDamage = true;
    private float cooldownDuration = 0.5f;
    private float lastDamageTime = 0f;
    public GameObject slime;

    public bool die = false;

    public bool StartBattle = false;
    public bool startPointSet = false;

    private void Awake()
    {
        emily = GameObject.FindGameObjectWithTag("Emily");
    }

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        hitCount = 0;
    }

    private void Update()
    {
        if (!die)
        {
            if (StartBattle)
            {
                StartBattle = false;
                SetNewDestination();
                startPointSet = true;
            }

            if(startPointSet) 
            {
                transform.position = Vector2.MoveTowards(transform.position, wayPoint, speed * Time.deltaTime);
                if (Vector2.Distance(transform.position, wayPoint) < range)
                {
                    SetNewDestination();
                }
                ShootFire();
            }
           
        }


    }

    void SetNewDestination()
    {
        wayPoint = new Vector2(Random.Range(-maxDistance, maxDistance), Random.Range(-maxDistance, maxDistance));

    }

    void ShootFire()
    {
        direction = (emily.transform.position - transform.position).normalized;
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

    private void TakeDamage(int amount)
    {
        health -= amount;
        
        if (health <= 0)
        {
            health = 0;
            die = true;
            GameManager.Instance.waterBoss = true;
        }
        else
        {
            hitCount += amount;
            if (hitCount >= 5)
            {
                Instantiate(slime, shootPoint.position, transform.rotation);

                hitCount = 0;
            }
        }
        healthBar.SetHealth(health);
    }

    public void Damage(int amount, Transform bullet)
    {
        TakeDamage(amount);
    }

    public void StartTheBattle()
    {
        StartBattle = true;
    }

}
