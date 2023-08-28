using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 6f;
    [SerializeField] healthbar healthbar;
    private Animator myAnim;

    private void Awake()
    {
        healthbar = GetComponentInChildren<healthbar>();
        myAnim = GetComponent<Animator>();
    }

    private void Start()
    {
        health = maxHealth;
        healthbar.UpdateHealthBar(health, maxHealth);
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthbar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            Die();
        }
        else
        {

            myAnim.SetTrigger("Hit");
        }
    }

    private void Die()
    {

        myAnim.SetTrigger("Dead");

        Invoke("DeactivateEnemy", 1.0f);
    }

    private void DeactivateEnemy()
    {
        gameObject.SetActive(false);
    }

}