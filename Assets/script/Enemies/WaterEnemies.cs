using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterEnemies : MonoBehaviour
{
    private void Start()
    {

        if (GameManager.Instance.water == true)
        {
            Destroy(gameObject);
        }


    }
    void Update()
    {
        if (transform.childCount <= 0)
        {
            GameManager.Instance.water = true;
            Destroy(gameObject);


        }
    }

}
