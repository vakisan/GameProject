using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class EnemyAI : MonoBehaviour {

    [SerializeField]
    public Transform target;
    private NavMeshAgent navMeshAgent;
    private NavMeshPath navMeshPath;
    private StateMachineSystem stateMachineSystem;

    private int shotToTakeDown = 5;
    private int originalShotToTakeDown;

    [Range(0,100)]
    public float speed = 5;

    public float distanceToTarget;

    public TMP_Text shotLeftUI;

    private void Awake(){
        target = GameObject.Find("Player").transform;
        originalShotToTakeDown = shotToTakeDown;
        navMeshAgent = GetComponent<NavMeshAgent>();
        stateMachineSystem = GetComponent<StateMachineSystem>();
        shotLeftUI = GameObject.Find("EnemyShotLeft").GetComponent<TMP_Text>();
    }

    public float CalculateDistanceToPlayer(){
        return Vector3.Distance(target.position, navMeshAgent.transform.position);
    }

    void Update(){
        distanceToTarget = CalculateDistanceToPlayer();
        stateMachineSystem.RunStateMachine(distanceToTarget,navMeshAgent,target);
    }

    public void DisplayShotsToTakeDown(){
        if(originalShotToTakeDown>= shotToTakeDown){
            shotLeftUI.text = "Shoot Enemy";
        }
        shotLeftUI.text = shotToTakeDown.ToString();
        if(shotToTakeDown<0){
           shotLeftUI.text = ""; 
        }
    }

    public bool DamageEnemy(){
        --shotToTakeDown;
        return shotToTakeDown < 0;
    }

}
