using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Player : MonoBehaviour
{
    public int maxHealth = 25;
    public int currentHealth;

    public int maxMana = 20;
    public int currentMana;


    public HealthBar healthBar;
    public ManaBar manaBar;

    private ShadowCaster2D shadow;

    Material material;
    float fade = 1f;
    private bool isDisolving = false;

    private GameObject weapon;

    public bool die = false;
    private Collider2D[] playerColliders;

    public Material blit;
    float hurt = 0f;
    float decayRate = 0.002f;



    void Start()
    {
        currentHealth = GameManager.Instance.emilyHealth;
        currentMana = GameManager.Instance.emilyMana;
        healthBar.SetHealth(currentHealth);
        manaBar.SetMana(currentMana);
        playerColliders = GetComponents<Collider2D>();
        shadow = GetComponent<ShadowCaster2D>();
        material = GetComponent<SpriteRenderer>().material;
        weapon = GameObject.FindGameObjectWithTag("Weapon");
 
    }

    private void Update()
    {

        if (isDisolving)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDisolving=false;
                shadow.enabled = false;
                Destroy(weapon);

            }
        }
        material.SetFloat("_Fade", fade);
        blit.SetFloat("_FullscreenIntensity", hurt);

        if (hurt > 0)
        {
            hurt -= decayRate * Time.deltaTime; 
            if (hurt <= 0)
            {
                hurt = 0; 
            }
        }
    }


    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        
        

        if (currentHealth <= 0)
        {            
            currentHealth = 0;
            isDisolving = true;
            Killed(true);

           

        }

        hurt += 0.002f;
        
        healthBar.SetHealth(currentHealth);
    }

    void Maxheal()
    {
        currentHealth = maxHealth;
    }

    void heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }

    void MaxMana()
    {
        currentMana = maxMana;
    }

    void PickMana(int amount)
    {
        currentMana += amount;
        if (currentMana >= maxMana)
        {
            currentMana = maxMana;
        }
    }


    private void OnDisable()
    {
        GameManager.Instance.emilyHealth = currentHealth;
    }

    public void Killed(bool killed)
    {
        die = killed;
        foreach (Collider2D collider in playerColliders)
        {
            collider.enabled = false;
        }
    }
}
