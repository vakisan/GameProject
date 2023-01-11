using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class StateAttack : State
{

    public PlayerHealth playerHealth;

    public GameObject player;

    private bool isAttacked = false;

    void Awake(){
        player = GameObject.Find("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
    }

    public override State RunCurrentState(float distanceToTarget,NavMeshAgent agent, Transform target)
    {
        if(!isAttacked){
            Rigidbody rigidBody = agent.gameObject.GetComponent<Rigidbody>();
            Vector3 originalVelocity = rigidBody.velocity;
            Vector3 originalAngularVelocity = rigidBody.angularVelocity;
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            rigidBody.AddRelativeForce(-originalVelocity* Time.deltaTime, ForceMode.Impulse);
            // Rigidbody rigidbodyPlayer = player.GetComponent<Rigidbody>();
            // rigidBody 
            StartCoroutine("Wait");
            rigidBody.velocity = originalVelocity;
            rigidBody.angularVelocity =originalAngularVelocity;
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
