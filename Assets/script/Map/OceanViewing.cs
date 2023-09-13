using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanViewing : MonoBehaviour
{
    camera_movement cm;
    Camera cam;

    private void Start()
    {
        cm = FindObjectOfType<camera_movement>();
        cam = Camera.main;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Emily"))
        {
            cm.minPosition = new Vector2( -3, 0.9f);
            cm.maxPosition = new Vector2( 12.33f, 0.9f);
            cam.orthographicSize = 10;

        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Emily"))
        {
            cm.minPosition = new Vector2(-100, -100);
            cm.maxPosition = new Vector2(100, 100);
            cam.orthographicSize = 5;

        }

    }
}
