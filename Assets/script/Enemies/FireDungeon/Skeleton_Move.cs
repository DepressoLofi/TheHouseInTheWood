using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_Move : StateMachineBehaviour
{
    public float speed = 2.5f;

    public float attackRange = 1;

    Transform player;
    Rigidbody2D rb;
    SkeletonGuy skg;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Emily").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        skg = animator.GetComponent<SkeletonGuy>();

    }
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (Vector2.Distance(player.position, rb.position) <= attackRange)
        {
            animator.SetTrigger("attack");
        }
        else
        {
            Vector2 target = new Vector2(player.position.x, player.position.y);
            Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
            rb.MovePosition(newPos);
        }

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("attack");
    }


}
