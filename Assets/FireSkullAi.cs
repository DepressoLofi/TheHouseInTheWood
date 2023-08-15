using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireSkullAi : MonoBehaviour
{
    [SerializeField] float health, maxHealth = 1f;
    [SerializeField] healthbar healthbar;

    private void Awake()
    {
        healthbar = GetComponentInChildren<healthbar>();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        healthbar.UpdateHealthBar(health, maxHealth);

        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Invoke("DeactivateEnemy", 1.0f);
    }

    private void DeactivateEnemy()
    {
        gameObject.SetActive(false);
    }



}
