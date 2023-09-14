using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GhostDialogueTrigger : MonoBehaviour
{
    [Header("chat icon")]
    [SerializeField] private GameObject chatIcon;


    [PortLabelHidden]
    public bool playerInRange;
    private bool saving = false;


    public GameObject dialogue;
    public GameObject dialSuccess;

    private character_movement playerMovement;

    private Weapon weapon;

    private AudioSource success;

    private Player player; 


    private void Awake()
    {
        playerInRange = false;
        chatIcon.SetActive(false);
    }

    private void Start()
    {
        player = GetComponent<Player>();
        playerMovement = GameObject.FindGameObjectWithTag("Emily").GetComponent<character_movement>();
        GameObject weaponObject = GameObject.FindGameObjectWithTag("Weapon");
        if (weaponObject != null)
        {
            weapon = weaponObject.GetComponent<Weapon>();
        }
        else
        {
            weapon = null; 
        }
        success = GetComponent<AudioSource>();  

    }

    private void Update()
    {
        if (playerInRange)
        {
            if(weapon != null)
            {
                weapon.DisableToShoot();
            }
            chatIcon.SetActive(true);
            if (Input.GetMouseButtonDown(0))
            {
                playerMovement.SetCanMove(false);
                if (!saving)
                {
                    GetDialogue();
                } else if(saving)
                {
                    dialSuccess.SetActive(false);
                    saving = false;
                    playerMovement.SetCanMove(true);
                }
                
            } 
        }
        else
        {
            if (weapon != null)
            {
                weapon.EnableToShoot();
            }
            chatIcon.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Emily")
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Emily")
        {
            playerInRange = false;
        }
    }

    private void GetDialogue()
    {
        dialogue.SetActive(true);
    }

    public void SavingGame()
    {
        saving = true;
        SavePlayer();
        success.Play();
        dialogue.SetActive(false);
        dialSuccess.SetActive(true);
    }

    public void NotSaving()
    {
        dialogue.SetActive(false);
        playerMovement.SetCanMove(true);
    }


    public void SavePlayer()
    {
        SavingSystem.SavePlayer(player);
    }

}
