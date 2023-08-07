using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_AI : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    private Enemy enemy; 
    public Transform homePos;
    [SerializeField] public float speed;
    [SerializeField] private float maxRange;
    [SerializeField] private float minRange;
    [SerializeField] private float damageAmount = 1f; 
    private void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<character_movement>().transform;
        enemy = GetComponent<Enemy>(); 
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

        
        Vector3 moveDirection = (target.position - transform.position).normalized;

        
        moveDirection.z = 0f;

        
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
        if (collision.CompareTag("Player")) 
        {
            
            enemy.TakeDamage(damageAmount);
        }
    }
}
