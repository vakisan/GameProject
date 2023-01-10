using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateHelp : State
{
    public override State RunCurrentState(float distanceToTarget,NavMeshAgent agent, Transform target)
    {
        Debug.Log("Help");
        return this;
    }
}
