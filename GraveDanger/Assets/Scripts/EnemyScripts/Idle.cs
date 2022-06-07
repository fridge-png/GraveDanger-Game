using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : EnemyBase
{
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        if (!initialized)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
        }
        agent.Stop();

    }
}
