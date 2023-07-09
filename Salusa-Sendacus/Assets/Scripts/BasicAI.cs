using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{

    public Transform target;

    private Vector3 waypointTarget;

    public Transform[] waypoints;

    int waypointindex;


    private EnemyReferences enemyReferences;

    private float pathUpdateDeadline;

    public float patrolDistanceMultiplier = 10;
    private float patrolDistance;
    private float attackingDistance;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    private void Awake()
    {
        enemyReferences = GetComponent<EnemyReferences>();
    }
    // Start is called before the first frame update
    void Start()
    {
        patrolDistance = (enemyReferences.navMeshagent.stoppingDistance) * patrolDistanceMultiplier;
        attackingDistance = enemyReferences.navMeshagent.stoppingDistance;
        UpdateDestination();
    }

    // Update is called once per frame
    void Update()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        if (targetDistance >= patrolDistance && Vector3.Distance(transform.position, waypointTarget) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
        else if (targetDistance < patrolDistance)
        {
            bool inRange = Vector3.Distance(transform.position, target.position) <= attackingDistance;

            if (inRange)
            {
                LookAtTarget();
            }
            else
            {
                UpdatePath();
            }
            enemyReferences.animator.SetBool("Attacking", inRange);
        }
        if (enemyReferences.navMeshagent.desiredVelocity.sqrMagnitude > 0)
        {
            enemyReferences.animator.SetFloat("Speed", 0.9f);
        }
        else
        {
            enemyReferences.animator.SetFloat("Speed", 0);
        }

        //if (Vector3.Distance(transform.position, waypointTarget) < 1)

        // if (target != null)
        //{
        //    bool inRange = Vector3.Distance(transform.position, target.position) <= attackingDistance;

        //    if (inRange)
        //   {
        //      LookAtTarget();
        //   }
        //  else
        //  {
        // UpdatePath();
        // }
        //  enemyReferences.animator.SetBool("Attacking", inRange);
        // }
        // if (enemyReferences.navMeshagent.desiredVelocity.sqrMagnitude > 0)
        //  {
        //     enemyReferences.animator.SetFloat("Speed", 0.9f);
        //  }
        //  else
        //  {
        //     enemyReferences.animator.SetFloat("Speed", 0);
        //  }
    }
    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);

    }

    private void UpdateDestination()
    {
        waypointTarget = waypoints[waypointindex].position;
        enemyReferences.navMeshagent.SetDestination(waypointTarget);
    }
    private void UpdatePath()
    {
        enemyReferences.navMeshagent.SetDestination(target.position);
    }
    private void IterateWaypointIndex()
    {
        waypointindex++;
        if (waypointindex == waypoints.Length)
        {
            waypointindex = 0;
        }
    }
}
