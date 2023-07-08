using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{

    public Transform target;


    private EnemyReferences enemyReferences;

    private float pathUpdateDeadline;

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
        attackingDistance = enemyReferences.navMeshagent.stoppingDistance;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
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


    }
    private void LookAtTarget()
    {
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);

    }
    private void UpdatePath()
    {
        // if (Time.time >= pathUpdateDeadline)
        // {
        //   Debug.Log("Updating PAth");
        //    pathUpdateDeadline = Time.time + enemyReferences.parthUpdateDelay;
        enemyReferences.navMeshagent.SetDestination(target.position);
        // }


    }
}
