using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;



public class CharacterInteraction : MonoBehaviour
{
    private StatueD targetStatue;

    private void Update()
    {
        // Check for mouse click events
        if (Input.GetMouseButtonDown(0))
        {
           
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

            if (hit.collider != null)
            {
                
                StatueD statue = hit.collider.GetComponent<StatueD>();
                if (statue != null)
                {
                    DialogueManager.Instance.ShowDialogue(statue.dialogue);
                }
            }
        }
    }
}
