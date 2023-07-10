using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterInteraction : MonoBehaviour
{
    private StatueD targetStatue;
    private bool isInteracting = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        StatueD statue = collision.GetComponent<StatueD>();
        if (statue != null)
        {
            targetStatue = statue;
            isInteracting = true;
            Interaction();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        StatueD statue = collision.GetComponent<StatueD>();
        if (statue != null && statue == targetStatue)
        {
            targetStatue = null;
            isInteracting = false;
            DialogueManager.Instance.HideDialogue();
        }
    }

    private void Update()
    {
        // Check for player input to interact with the statue
        if (Input.GetKeyDown(KeyCode.Space) && targetStatue != null && isInteracting)
        {
            DialogueManager.Instance.NextDialogueLine();
        }
    }

    private void Interaction()
    {
        // Show dialogue when interacting with the statue
        DialogueManager.Instance.ShowDialogue(targetStatue.dialogue);
    }
}
