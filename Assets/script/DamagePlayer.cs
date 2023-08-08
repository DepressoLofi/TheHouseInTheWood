using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.SceneManagement;

public class DamagePlayer : MonoBehaviour
{
    private Player emily;
    public float waitToHurt = 1f;
    public bool isTouching;
    [SerializeField]
    private int damageToGive = 10;
   
    void Start()
    {
        emily = FindObjectOfType<HealthManager>();
    }

    
    void Update()
    {
        /*if (reloading)
        {
            waitToLoad -= Time.deltaTime;
            if (waitToLoad <= 0) 
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
        }*/

        if(isTouching)
        {
            waitToHurt -= Time.deltaTime;
            if (waitToHurt <= 0)
            {
                healthMan.DamagePlayer(damageToGive);
                waitToHurt = 1f;
            }
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Emily")
        {
            //Destroy(other.gameObject);
            //other.gameObject.SetActive(false);

            other.gameObject.GetComponent<HealthManager>().DamagePlayer(damageToGive);
            //reloading = true;   
            // SceneManager.LoadScene("enemy");
          

        }
    }


    private void OnCollisionStay2D(Collision2D other)
    {

        if(other.collider.tag== "Emily")
        {
            isTouching = true;
        }
        
        
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if(other.collider.tag == "Emily")
        { 
            isTouching = false;
            waitToHurt = 2f;
        }

        
    }
}

