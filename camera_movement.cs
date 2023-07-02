using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_movement : MonoBehaviour
{
    public Transform Emily;
    [SerializeField] float smoothing = 0.5f;

    public Vector2 maxPosition;
    public Vector2 minPosition;

    void Update()
    {
        if (transform.position != Emily.position)
        {
            Vector3 targetPosition = new Vector3(Emily.position.x, Emily.position.y, transform.position.z);
            targetPosition.x = Mathf.Clamp(targetPosition.x, minPosition.x, maxPosition.x);
            targetPosition.y = Mathf.Clamp(targetPosition.y, minPosition.y, maxPosition.y);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);
        }
    }
}
