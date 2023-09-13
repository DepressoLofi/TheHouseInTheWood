using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutScenePlayeNature : MonoBehaviour
{
    private void Awake()
    {
        if (GameManager.Instance.nature == true)
        {
            Destroy(gameObject);
        }
    }
}
