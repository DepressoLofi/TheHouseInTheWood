using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 6f;

    [SerializeField]healthbar healthbar;

    private void Awake()
    {
        healthbar = GetComponentInChildren<healthbar>();
    }
    private void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damageAmount)
    {
    
        health -= damageAmount;
        healthbar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
