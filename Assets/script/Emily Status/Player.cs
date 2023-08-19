using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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



    void Start()
    {
        currentHealth = GameManager.Instance.emilyHealth;
        currentMana = GameManager.Instance.emilyMana;
        healthBar.SetHealth(currentHealth);
        manaBar.SetMana(currentMana);

        shadow = GetComponent<ShadowCaster2D>();
        material = GetComponent<SpriteRenderer>().material;
        weapon = GameObject.FindGameObjectWithTag("Weapon");
    }

    private void Update()
    {

        if(Input.GetKeyUp(KeyCode.Space)) 
        {
            TakeDamage(5);
        }

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
    }
}
