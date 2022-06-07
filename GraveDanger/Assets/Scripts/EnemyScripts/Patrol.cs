using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : EnemyBase
{

    private Vector3[] waypoints;
    private int currentWayPoint = 0;

    private void Awake()
    {

        waypoints = new Vector3[2];


    }


    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!initialized)
        {
            base.OnStateEnter(animator, stateInfo, layerIndex);
        }

        for (int i = 0; i < 3; i++)
        {
            waypoints[0] = enemy.transform.position + new Vector3(0, 0, 1);
            waypoints[1] = enemy.transform.position + new Vector3(-2, 0, -2);
        }
        agent.Resume();
        agent.SetDestination(waypoints[currentWayPoint]);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (waypoints.Length != 0)
        {
            if (Vector3.Distance(enemy.transform.position, waypoints[currentWayPoint]) < 1)
            {
                currentWayPoint = (currentWayPoint + 1) % waypoints.Length;
            }
            agent.SetDestination(waypoints[currentWayPoint]);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }


}
