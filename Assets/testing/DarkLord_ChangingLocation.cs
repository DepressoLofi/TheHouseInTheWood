using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkLord_ChangingLocation : StateMachineBehaviour
{

    DarkLord dk;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dk = animator.GetComponent<DarkLord>();
        dk.ChoosePoint();
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("AppearOne");
    }



}
