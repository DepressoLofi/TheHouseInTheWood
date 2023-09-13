using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlayed : MonoBehaviour
{
    private void Awake()
    {
        if (GameManager.Instance.water == true)
        {
            Destroy(gameObject);
        }
    }

}
