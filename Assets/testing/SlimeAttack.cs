using Ink.Parsed;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeAttack : MonoBehaviour
{
    private float attack;
    [SerializeField] private float attackSpeed;
    public bool stop = false;
    bool attackRange = false;


    private Player player;
    public Slime slime;


    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Emily").GetComponent<Player>();
        attack = attackSpeed;
    }


    private void Update()
    {
        if (attackRange)
        {
            DealDamage();
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Emily"))
        {
            stop = true;
            attackRange = true;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Emily"))
        {
            Invoke("ResetStopping", 0.5f);
            

            attackRange = false;
            attack = attackSpeed; 
        }

    }

    private void ResetStopping()
    {
        stop = false;
    }

    private void DealDamage()
    {
        if(attack >= attackSpeed)
        {
            player.TakeDamage(2);
            attack = 0;
        }
        else
        {
            Debug.Log("this work");
            attack+= Time.deltaTime;
        }

    }

}
