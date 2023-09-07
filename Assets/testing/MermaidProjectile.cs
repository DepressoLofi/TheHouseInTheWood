using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MermaidProjectile : MonoBehaviour
{
    public float speed = 4.5f;
    private Transform target;
    private Player player;
    [SerializeField] private int damageAmount;


    private Vector3 direction;
    private float yOffset = 1f;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Emily").GetComponent<Player>();
        target = GameObject.FindGameObjectWithTag("Emily").transform;
        Destroy(gameObject, 3f);
        Shoot();
    }

    private void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void Shoot()
    {
        Vector3 targetPosition = target.position + new Vector3(0, yOffset, 0);
        direction = (targetPosition - transform.position).normalized;
    }
    void Hit()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Emily"))
        {
            player.TakeDamage(damageAmount);
            Hit();
        }
        if (collision.gameObject.CompareTag("Control"))
        {
            Hit();
        }
    }
}
