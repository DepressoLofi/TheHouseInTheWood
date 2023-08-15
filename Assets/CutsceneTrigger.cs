using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CutsceneTrigger : MonoBehaviour
{
    public PlayableDirector cutscene;
    private bool played = false;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Emily"))
        {
            if (!played)
            {    
                cutscene.Play();
                played = true;
            }

        }
       
    }
}
