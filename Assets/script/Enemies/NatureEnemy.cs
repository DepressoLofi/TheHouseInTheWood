using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureEnemy : MonoBehaviour
{
    private void Start()
    {

        if (GameManager.Instance.nature == true)
        {
            Destroy(gameObject);
        }


    }
    void Update()
    {
        if (transform.childCount <= 0)
        {
            GameManager.Instance.nature = true;
            Destroy(gameObject);


        }
    }
}
