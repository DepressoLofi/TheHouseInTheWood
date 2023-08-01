using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalName : MonoBehaviour
{
    [SerializeField] private GameObject DungeonName;

    private bool playerInRange;

    private void Awake()
    {
        playerInRange = false;
        DungeonName.SetActive(false);
    }

    void Update()
    {
        if (playerInRange)
        {
            DungeonName.SetActive(true);
        }
        else
        {
            DungeonName.SetActive(false);
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
