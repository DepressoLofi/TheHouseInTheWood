using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenePlayedFire : MonoBehaviour
{
    private void Awake()
    {
        if (GameManager.Instance.fire == true)
        {
            Destroy(gameObject);
        }
    }


}
