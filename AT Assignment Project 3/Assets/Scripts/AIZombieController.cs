using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Timeline;

public class AIZombieController : MonoBehaviour
{
    public NavMeshAgent navmesh;
    [Range(0, 100)] public float speed;
    [Range(0, 500)] public float walkRadius;
    [SerializeField]
    public GameObject Player;
    public float pushbackForce = 4;

    public void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();

        if (navmesh != null)
        {
            navmesh.speed = speed;
            navmesh.SetDestination(RandomNavMeshLocation());
        }
    }

    public void Update()
    {
        if (navmesh != null && navmesh.remainingDistance <= navmesh.stoppingDistance)
        {
            navmesh.SetDestination(RandomNavMeshLocation());
        }
        if (Vector3.Distance(this.transform.position, Player.transform.position) <= 10F)
        {
            chase();
        }
        if (Vector3.Distance(this.transform.position, Player.transform.position) > 10F)
        {
            endChase();
        }

        if (Vector3.Distance(this.transform.position, Player.transform.position) <= 1.5F)
        {
            Attack();
        }

        if (SafeZone.isSafe)
        {
           endChase();
        }
    }

    public void chase()
    {
        navmesh.destination = Player.transform.position;
        speed = 3;
        navmesh.speed = speed;
    }

    public void Attack()
    {
        //Debug.Log("ATTACK");
        PlayerController.PlayerHealth -= 50;      
    }

    public void endChase()
    {
        navmesh.destination = RandomNavMeshLocation();
        speed = 0.4F;
        navmesh.speed = speed;
    }


    public Vector3 RandomNavMeshLocation()
    {
        Vector3 finalPosition = Vector3.zero;
        Vector3 randomPosition = Random.insideUnitSphere * walkRadius;
        randomPosition += transform.position;

        if (NavMesh.SamplePosition(randomPosition, out NavMeshHit hit, walkRadius, 1))
        {
            finalPosition = hit.position;
        }
        return finalPosition;
    }
}
