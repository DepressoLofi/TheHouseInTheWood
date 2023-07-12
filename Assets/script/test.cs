using UnityEngine;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MouseTest : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Left mouse button clicked");
        }
    }
}
