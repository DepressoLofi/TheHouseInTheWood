using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestingSystem : MonoBehaviour
{
    private Player player;
    private AudioSource sound;

    private void Start()
    {
        sound = GetComponent<AudioSource>();
        GameObject emilyObject = GameObject.FindGameObjectWithTag("Emily");
        if (emilyObject != null)
        {
            player = emilyObject.GetComponent<Player>();
        }
        else
        {
            Debug.LogError("Could not find an object with the 'Emily' tag.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Emily"))
        {
            player.Maxheal();
            sound.Play();
        }
    }
}
