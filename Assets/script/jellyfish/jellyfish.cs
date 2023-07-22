using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class jellyfish : MonoBehaviour
{

    [SerializeField] float speed = 0.5f;
    private float deadzone = 13f;
  

    void Update()
    {
        transform.position = transform.position + (Vector3.up * speed) * Time.deltaTime;

        if(transform.position.y > deadzone)
        {
            Destroy(gameObject);
        }
    }
}
