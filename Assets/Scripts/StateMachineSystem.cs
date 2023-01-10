using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateMachineSystem : MonoBehaviour
{   
    public State currentState;
    public StateAttack attackState;
    public StateChase chaseState;
    public StateIdle idleState;

    void Awake(){
        attackState = GetComponent<StateAttack>();
        chaseState = GetComponent<StateChase>();
        idleState = GetComponent<StateIdle>();
    }

    public void RunStateMachine(float distanceToTarget,NavMeshAgent agent, Transform target){
        SwitchNextState(distanceToTarget);
        currentState.RunCurrentState(distanceToTarget,agent,target);
        Debug.Log(currentState);
    }

    void SwitchNextState(float distanceToTarget){
        if(distanceToTarget<= 2){
            currentState = attackState;
        }
        else if(distanceToTarget <= 50){
            currentState = chaseState;
        }
        else{
            currentState = idleState;
        }
    }
}
