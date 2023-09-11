using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    Animator animator;
    private void Start()
    {
        animator = GetComponent<Animator>();
        if (GameManager.Instance.fire == true)
        {
            Destroy(gameObject);
        }


    }
    void Update()
    {
        if(transform.childCount <= 0)
        {
            GameManager.Instance.fire = true;
            animator.SetTrigger("Boom");
            Invoke("DestroyTheObject", 0.7f);
        }
    }

    void DestroyTheObject()
    {
        Destroy(gameObject);
    }
}
