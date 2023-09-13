using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lord_GoingRandom : StateMachineBehaviour
{
    DarkLord dk;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dk = animator.GetComponent<DarkLord>();
        dk.GoToPoint();
    }



    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("AppearTwo");
        animator.ResetTrigger("DisappearOne");
    }


}
