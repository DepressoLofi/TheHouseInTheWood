using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public int maxHealth = 25;
    public int currentHealth;

    private character_movement emily;

    public HealthBar healthBar;


    private ShadowCaster2D shadow;

    Material material;
    float fade = 1f;
    private bool isDisolving = false;

    private GameObject weapon;

    public bool die = false;
    private Collider2D[] playerColliders;

    public Material blit;
    float hurt = 0f;
    float decayRate = 0.006f;

    private camera_movement cm;
    private AudioSource sfx;


    void Start()
    {
        emily = GetComponent<character_movement>();
        currentHealth = GameManager.Instance.emilyHealth;
        healthBar.SetHealth(currentHealth);
        playerColliders = GetComponents<Collider2D>();
        shadow = GetComponent<ShadowCaster2D>();
        material = GetComponent<SpriteRenderer>().material;
        weapon = GameObject.FindGameObjectWithTag("Weapon");
        cm = FindObjectOfType<camera_movement>();
        sfx = GetComponent<AudioSource>();
 
    }

    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(3);
        }
        */

        if (isDisolving)
        {
            fade -= Time.deltaTime;

            if (fade <= 0f)
            {
                fade = 0f;
                isDisolving=false;
                shadow.enabled = false;
                Destroy(weapon);
                StartCoroutine(LoadLevel("Dead"));

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
        if (!emily.transitioning && !cm.CutScene){
            currentHealth -= dmg;
            sfx.Play();

            if (currentHealth <= 0)
            {
                currentHealth = 0;
                isDisolving = true;
                Killed(true);
            }
            hurt += 0.003f;
            healthBar.SetHealth(currentHealth);

        }

    }

    public void Maxheal()
    {
        while(currentHealth < maxHealth)
        {
            currentHealth += 1;
            healthBar.SetHealth(currentHealth);
        }
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

    void heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
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
    IEnumerator LoadLevel(string sceneToLoad) { 
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneToLoad);
    }

}
