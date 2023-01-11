using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    //Enemy navmesh agent so the enemy can use the navmesh that has been baked onto the environment
    public NavMeshAgent agent;
    //Player transform for chase/attack movement of the enemies
    public Transform player;
    //Layermasks so the enemy can interract with the ground and the player appropriately
    public LayerMask defineGround, definePlayer;
    //Health to be used more once the player mechanics have been refined
    public float health;

    //Patrolling
    //Essentially these are used to calculate the randomised movement of the enemy when in the patrolling state
    //Random point within a set range for the enemy to move to
    public Vector3 walkPoint;
    //Used in order to determine whether a new walkpoint needs to be generated
    bool walkPointSet;
    //Describes the range in which a walkpoint can be determined
    public float walkPointRange;

    //Attacking
    //Used to delay attacks
    public float timeBetweenAttacks;
    //Used to see if an enemy has just attacked
    bool hasAttacked;

    //States
    //sightrange is used to determine the range in which the player is counted as being in sight
    ////attackrange is used to determine the range in which the player is counted as being in attack distance
    public float sightRange, attackRange;
    //These booleans are used to manage whether the enemy should be in the patrol state, the chase state, or the attack state
    public bool playerInSight, playerInAttack;

    //Initial reference to player and navmesh agent are set upon instantiation
    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check if player in sight or attack range by using checksphere
        playerInSight = Physics.CheckSphere(transform.position, sightRange, definePlayer);
        playerInAttack = Physics.CheckSphere(transform.position, attackRange, definePlayer);

        //Setting the state based on which range(s) the player is in
        if (!playerInSight && !playerInAttack) Patrol();
        if (playerInSight && !playerInAttack) Chase();
        if (playerInSight && playerInAttack) Attack();
    }

    private void Patrol()
    {
        //If there's no walkpoint set, call a function to determine the walkpoint
        if (!walkPointSet) SearchWalkPoint();
        //If there is a walkpoint set, move the enemy via the navmesh to the walkpoint
        if (walkPointSet)
            agent.SetDestination(walkPoint);

        //Calculate the distance to the walkpoint
        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached, in which case set walkpointset to false so that another walkpoint can be determined
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Calc random range in the x axis and the z axis
        float randZ = Random.Range(-walkPointRange, walkPointRange);
        float randX = Random.Range(-walkPointRange, walkPointRange);

        //Set the walkpoint to a vector 3 which factors in the current position as well as the new random x point and the random z point
        walkPoint = new Vector3(transform.position.x + randX, transform.position.y, transform.position.z + randZ);

        //Set the waklpoint to true
        if (Physics.Raycast(walkPoint, -transform.up, 2f, defineGround))
            walkPointSet = true;
    }

    private void Chase()
    {
        //Move the enemy via the navmesh to the player
        agent.SetDestination(player.position);
    }

    private void Attack()
    {
        //Stop enemy moving
        agent.SetDestination(transform.position);
        //The enemy will look at the player
        transform.LookAt(player);

        if (!hasAttacked)
        {
            //Insert attack code in here
            //If the enemy has just attacked, then wait a set time before allowing the enemy to attack again
            hasAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        //Resets the hasattacked boolean so the enemy can attack again
        hasAttacked = false;
    }
}
