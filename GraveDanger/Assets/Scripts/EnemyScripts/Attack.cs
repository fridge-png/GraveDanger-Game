using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : EnemyBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!initialized)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
        }
        agent.Stop();

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        // fireRate -= Time.deltaTime;

        // if (fireRate <= 0)
        // {
        //     Player.instance.takeDamage(10);
        // }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
