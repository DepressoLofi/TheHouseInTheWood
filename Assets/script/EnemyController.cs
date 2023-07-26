using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
public class EnemyController : MonoBehaviour
{
   
    private Animator myAnim;
    private Transform target;
    public Transform homePos;
    [SerializeField]
    public float speed;
    [SerializeField]
    private float maxRange;
    [SerializeField]
    private float minRange;


    private void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<character_movement>().transform;
    }

    private void Update()
    {

        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position)>= minRange)
        {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position,transform.position) >= maxRange)
        {
            GoOrigin();
        }
    }

    public void FollowPlayer()
    {
        myAnim.SetBool("isMoving", true);
        myAnim.SetFloat("moveX", (target.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (target.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
    }
    public void GoOrigin()
    {
        myAnim.SetFloat("moveX", (homePos.position.x - transform.position.x));
        myAnim.SetFloat("moveY", (homePos.position.y - transform.position.y));
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, homePos.position) == 0)
        {
            myAnim.SetBool("isMoving", false);
        }
    }
}
