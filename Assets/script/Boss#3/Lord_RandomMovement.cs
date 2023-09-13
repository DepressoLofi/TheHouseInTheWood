using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Lord_RandomMovement : StateMachineBehaviour
{
    DarkLord dk;


    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dk = animator.GetComponent<DarkLord>();
        dk.EnableTheCollider();

    }

  
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
            dk.RandomMovement();

    }


    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        dk.DisableTheCollider();
    }



}
