using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomMove : MonoBehaviour
{

    public Vector2 cameraMinChange;
    public Vector2 cameraMaxChange;
    private camera_movement cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.GetComponent<camera_movement>();
    }



    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Emily"))
        {
                cam.minPosition = cameraMinChange;
                cam.maxPosition = cameraMaxChange;
        }

    }
}
