using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateChase : State
{
    public override State RunCurrentState(float distanceToTarget,NavMeshAgent agent, Transform target)
    {
        agent.SetDestination(target.position);
        return this;
    }
}
