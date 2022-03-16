using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIZombieController : MonoBehaviour
{
    public NavMeshAgent navmesh;
    [Range(0, 100)] public float speed;
    [Range(0, 500)] public float walkRadius;
    [SerializeField]
    public GameObject Player;

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
            navmesh.destination = Player.transform.position;
            speed = 3;
        }
        if (Vector3.Distance(this.transform.position, Player.transform.position) > 10F)
        {
            navmesh.destination = RandomNavMeshLocation();
            speed = 0.4F;
        }
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
