using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounterWater : MonoBehaviour
{
    Animator animator;
    
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (GameManager.Instance.water == true)
        {
            Destroy(gameObject);
        }


    }
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length <= 0)
        {
            animator.SetTrigger("Boom");
            Invoke("DestroyTheObject", 0.7f);
        }
    }

    void DestroyTheObject()
    {
        Destroy(gameObject);
    }
}
