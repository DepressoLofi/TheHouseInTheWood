using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud_movement : MonoBehaviour
{
    [SerializeField] float speed = 0.5f;
    private float deadzoneY = 42f;
    private float deadzoneX = -26f;

    void Update()
    {

        Vector3 movementDirection = new Vector3(-1f, 1f, 0f).normalized;

        transform.position = transform.position + (movementDirection * speed) * Time.deltaTime;

        if (transform.position.y > deadzoneY || transform.position.x < deadzoneX)
        {
            Destroy(gameObject);
        }
    }

}
