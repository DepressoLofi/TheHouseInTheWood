using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallShoot : MonoBehaviour
{

    private Player player;
    [SerializeField] private int damageAmount;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Emily").GetComponent<Player>();

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
