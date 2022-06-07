using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : StateMachineBehaviour
{

    protected GameObject enemy;
    protected UnityEngine.AI.NavMeshAgent agent;

    protected Enemy enemyScript;
    protected bool initialized = false;
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

        enemy = animator.gameObject;

        agent = enemy.transform.parent.GetComponent<UnityEngine.AI.NavMeshAgent>();

        initialized = true;

    }

}
