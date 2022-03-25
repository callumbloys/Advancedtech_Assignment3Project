using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AISurvivorsController : MonoBehaviour
{
    public NavMeshAgent navmesh;
    [Range(0, 100)] public float speed;
    [Range(0, 500)] public float walkRadius;
    [SerializeField]
    public GameObject Player;

    // Start is called before the first frame update
    void Start()
    {
        navmesh = GetComponent<NavMeshAgent>();

        if (navmesh != null)
        {
            navmesh.speed = speed;
            navmesh.SetDestination(RandomNavMeshLocation());
        }
    }

    // Update is called once per frame
    void Update()
    {
        navmesh.SetDestination(RandomNavMeshLocation());
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
