using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateIdle : State
{   
    [Range(0,100)]
    public float walkRadius = 25;

    public override State RunCurrentState(float distanceToTarget,NavMeshAgent agent, Transform target)
    {
        if(agent!= null && agent.remainingDistance <= agent.stoppingDistance){
            agent.SetDestination(Roam());
        }

        return this;
    }

    
    public Vector3 Roam(){
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition = transform.position + randomPosition;
        if(NavMesh.SamplePosition(randomPosition,out NavMeshHit hit, walkRadius,1)){
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
