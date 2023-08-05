using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [Header("chat icon")]
    [SerializeField] private GameObject chatIcon;

    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJson;

    private bool playerInRange;



    private void Awake()
    {
        playerInRange = false;
        chatIcon.SetActive(false);
    }

    private void Update()
    {
        if (playerInRange && !DialManager.Instance.dialogueIsPlaying)
        {
            chatIcon.SetActive(true);
           if (Input.GetMouseButtonDown(0))
            {
                DialManager.Instance.EnterDialogueMode(inkJson);   
            }
        }
        else
        {
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
}
