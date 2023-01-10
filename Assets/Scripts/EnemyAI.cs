using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    private Transform target;
    private NavMeshAgent navMeshAgent;
    private NavMeshPath navMeshPath;
    private StateMachineSystem stateMachineSystem;

    [Range(0,100)]
    public float speed = 5;

    public float distanceToTarget;

    private void Awake(){
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachineSystem = GetComponent<StateMachineSystem>();
    }

    public float CalculateDistanceToPlayer(){
        return Vector3.Distance(target.position, navMeshAgent.transform.position);
    }

    void Update(){
        distanceToTarget = CalculateDistanceToPlayer();
        stateMachineSystem.RunStateMachine(distanceToTarget,navMeshAgent,target);
    }

}
