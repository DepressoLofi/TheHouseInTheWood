using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public Transform Emily;
    [SerializeField] float smoothing = 0.5f;
 
    void Update()
    {
        if(transform.position != Emily.position)
        {
            Vector3 target_position = new(Emily.position.x, Emily.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, target_position, smoothing);
        }
        
    }
}
