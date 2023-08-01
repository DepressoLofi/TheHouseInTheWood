using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class MouseAim : MonoBehaviour
{
    public Transform firePoint;
    private Vector2 fireDirection = Vector2.up; 
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
           
            Vector3 mousePosition = Input.mousePosition;

            
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(mousePosition);
            worldMousePosition.z = 0f; // Ensure z position is 0 (2D plane)

            // Calculate the direction from the fire point to the mouse position
            fireDirection = (worldMousePosition - firePoint.position).normalized;
        }
    }

    public Vector2 GetFireDirection()
    {
        return fireDirection;
    }
}
