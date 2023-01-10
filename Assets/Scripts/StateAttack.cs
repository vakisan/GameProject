using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateAttack : State
{

    public PlayerHealth playerHealth;

    private bool isAttacked = false;

    void Awake(){
        playerHealth = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    public override State RunCurrentState(float distanceToTarget,NavMeshAgent agent, Transform target)
    {
        if(!isAttacked){
            StartCoroutine("Wait");
        }
        return this;
    }

    IEnumerator Wait(){
        isAttacked = true;
        yield return new WaitForSeconds(1);
        playerHealth.TakeDamage(Random.Range(5,10));
        isAttacked = false;
    }
}
