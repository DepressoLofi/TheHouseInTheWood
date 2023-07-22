using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public Transform Emily;
    [SerializeField] float smoothing = 0.5f;
    [SerializeField] float yOffset = 1.0f;
    public Vector2 minPosition;
    public Vector2 maxPosition;
    private void Start()
    {

    }

    void LateUpdate()
    {
        if (transform.position != Emily.position)
        {
            Vector3 target_position = new Vector3(Emily.position.x, Emily.position.y + yOffset, transform.position.z);
            target_position.x = Mathf.Clamp(target_position.x, minPosition.x, maxPosition.x);
            target_position.y = Mathf.Clamp(target_position.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, target_position, smoothing);
        }

    }
}