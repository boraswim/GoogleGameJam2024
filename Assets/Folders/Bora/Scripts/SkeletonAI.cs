using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SkeletonAI : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField] private Player _playerScript;
    [SerializeField] private Transform _player;

    public LayerMask ground, player;
    Vector3 destinationPoint;
    bool destinationPointSet;
    public float walkPointRange;

    public int SkeletonHp;
    public int attackValue;
    public float timeBetweenAttacks;
    private bool alreadyAttacked;

    public float sightRange, attackRange;
    public bool playerInSightRange, playerInAttackRange;

    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        StartCoroutine("DeathCheck");
    }

    void Update()
    {
        playerInSightRange = Physics.CheckSphere(transform.position, sightRange, player);
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, player);

        // Patrol / Chase / Attack

        if(!playerInSightRange && !playerInAttackRange) Patroling();
        if(playerInSightRange && !playerInAttackRange) ChasePlayer();
        if(playerInSightRange && playerInAttackRange) AttackPlayer();
    }

        void Patroling()
    {
        if(!destinationPointSet)
            SearchWalkPoint();
        if(destinationPointSet)
            _agent.SetDestination(destinationPoint);
        Vector3 distanceToDestinationPoint = transform.position - destinationPoint;
        if(distanceToDestinationPoint.magnitude < 1.0f)
            destinationPointSet = false;
    }
    
    void SearchWalkPoint()
    {
        float randomX = Random.Range(-walkPointRange, walkPointRange);
        float randomZ = Random.Range(-walkPointRange, walkPointRange);

        destinationPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if(Physics.Raycast(destinationPoint, -transform.up, 2.0f, ground))
        {
            destinationPointSet = true;
        }
    }

    void ChasePlayer()
    {
        _agent.SetDestination(_player.position);
    }

    void AttackPlayer()
    {
        
        _agent.SetDestination(transform.position);
        transform.LookAt(_player);
        if(!alreadyAttacked)
        {
            _playerScript.PlayerHit(attackValue);
            alreadyAttacked = true;
            StartCoroutine("ResetAttack");
        }
    }

    IEnumerator ResetAttack()
    {
        yield return new WaitForSeconds(timeBetweenAttacks);
        alreadyAttacked = false;
    }

    IEnumerator DeathCheck()
    {
        yield return new WaitUntil(() => SkeletonHp <= 0);
        Destroy(gameObject);
    }
}
