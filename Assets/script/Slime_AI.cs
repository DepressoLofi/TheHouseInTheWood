using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_AI : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    private Enemy enemy; // Reference to the Enemy script
    public Transform homePos;
    [SerializeField] public float speed;
    [SerializeField] private float maxRange;
    [SerializeField] private float minRange;
    [SerializeField] private float damageAmount = 1f; // Damage amount when hit by the player

    private void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<character_movement>().transform;
        enemy = GetComponent<Enemy>(); // Initialize the reference to the Enemy script
    }

    private void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) >= maxRange)
        {
            GoOrigin();
        }
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);

        // Calculate the direction from slime to the player
        Vector3 moveDirection = (target.position - transform.position).normalized;

        // Remove any rotation effect
        moveDirection.z = 0f;

        // Move the slime towards the player without changing its rotation
        Vector3 newPosition = transform.position + moveDirection * speed * Time.deltaTime;
        transform.position = newPosition;
    }

    public void GoOrigin()
    {
        myAnim.SetFloat("moveX", (homePos.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) // Assuming you have a "Player" tag
        {
            // Call the TakeDamage method of the enemy when hit by the player
            enemy.TakeDamage(damageAmount);
        }
    }
}
