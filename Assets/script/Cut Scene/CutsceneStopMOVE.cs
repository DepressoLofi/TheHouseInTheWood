using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneStopMOVE : MonoBehaviour
{
    private character_movement playerMovement;
    private BackgroundMusicManager musicManager;


    private void Start()
    {
        playerMovement = GameObject.FindGameObjectWithTag("Emily").GetComponent<character_movement>();
        musicManager = GameObject.FindGameObjectWithTag("BackgroundMusic").GetComponent<BackgroundMusicManager>();
        if (musicManager == null)
        {
            musicManager = null;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Emily"))
        {
            playerMovement.SetCanMove(false);
            musicManager.FadeOutMusic();
        }
    }

}
