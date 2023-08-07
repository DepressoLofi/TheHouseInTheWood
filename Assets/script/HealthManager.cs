using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Content;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth;

    private bool flashActive;
    [SerializeField]
    private float flashLength = 0f;
    private float flashCounter = 0f;
    private SpriteRenderer EmilySprite;

    void Start()
    {
        EmilySprite = GetComponent<SpriteRenderer>();
    }

   
    void Update()
    {
        if(flashActive)
        {
            if (flashCounter > flashLength * .99f)
            {
                EmilySprite.color = new Color(EmilySprite.color.r, EmilySprite.color.g, EmilySprite.color.b, 0f);
            }

            else if (flashCounter > flashLength * .82f)
            {
                EmilySprite.color = new Color(EmilySprite.color.r, EmilySprite.color.g, EmilySprite.color.b, 1f);
            }

            else if (flashCounter > flashLength * .66f)
            {
                EmilySprite.color = new Color(EmilySprite.color.r, EmilySprite.color.g, EmilySprite.color.b, 0f);
            }

            else if (flashCounter > flashLength * .49f)
                EmilySprite.color = new Color(EmilySprite.color.r, EmilySprite.color.g, EmilySprite.color.b, 1f);


            else if (flashCounter > flashLength * .33f)
                EmilySprite.color = new Color(EmilySprite.color.r, EmilySprite.color.g, EmilySprite.color.b, 0f);


            else if (flashCounter > flashLength * .16f)
                EmilySprite.color = new Color(EmilySprite.color.r, EmilySprite.color.g, EmilySprite.color.b, 1f);


            else if (flashCounter > 0f)
                EmilySprite.color = new Color(EmilySprite.color.r, EmilySprite.color.g, EmilySprite.color.b, 0f);


           else
            {
                EmilySprite.color = new Color(EmilySprite.color.r, EmilySprite.color.g, EmilySprite.color.b, 1f);
                flashActive = false;
            }

            flashCounter -= Time.deltaTime;
        }
    }

    public void DamagePlayer(int damageToGive)
    {
        currentHealth -= damageToGive;
        flashActive = true;
        flashCounter = flashLength;

        if (currentHealth <= 0)
        {

            gameObject.SetActive(false);
           
        }
       
    }
}
