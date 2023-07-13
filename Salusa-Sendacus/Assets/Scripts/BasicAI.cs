using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicAI : MonoBehaviour
{

    public Transform target;



    private Vector3 waypointTarget;

    public Transform[] waypoints;

    int waypointindex;

    Vector3 deathGround;
    public GameObject CanavarinKendisi;


    private EnemyReferences enemyReferences;

    public int canavarCan = 100;

    public int canavarHasar = 5;

    public float runSpeed = 10;
    public float walkSpeed = 5;

    private float pathUpdateDeadline;

    public float patrolDistanceMultiplier = 10;
    private float patrolDistance = 10;
    private float attackingDistance;

    public bool isPatroling;

    private bool isDead = false;

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
        ManageAnimations();
        if (canavarCan <= 0.0f && isDead == false)
        {
            isDead = true;
            CheckIfDead();
            Debug.Log("Canavar  cani yok ve İsdead çalıştırıldı");

        }
        if (isDead == false)
        {
            CheckPatroling();

            if (targetDistance > patrolDistance)
            {
                UpdateDestination();
                if (Vector3.Distance(transform.position, waypointTarget) < 1)
                {
                    IterateWaypointIndex();
                    UpdateDestination();
                }
                isPatroling = true;
            }
            else if (targetDistance < patrolDistance)
            {

                isPatroling = false;
                bool inRange = Vector3.Distance(transform.position, target.position) <= attackingDistance;



                UpdatePath();
                if (inRange)
                    LookAtTarget();

                enemyReferences.animator.SetBool("Attacking", inRange);
            }





        }
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

    private void ManageAnimations()
    {
        if (enemyReferences.navMeshagent.desiredVelocity.sqrMagnitude > 0 && isPatroling == false)
        {
            enemyReferences.animator.SetFloat("Speed", 0.9f);
            enemyReferences.animator.SetFloat("YurumeSpeed", 0);
        }
        else if (enemyReferences.navMeshagent.desiredVelocity.sqrMagnitude > 0 && isPatroling == true)
        {
            enemyReferences.animator.SetFloat("Speed", 0);
            enemyReferences.animator.SetFloat("YurumeSpeed", 0.9f);
        }
        else
        {
            enemyReferences.animator.SetFloat("YurumeSpeed", 0);
            enemyReferences.animator.SetFloat("Speed", 0);
        }
    }

    private void CheckPatroling()
    {
        if (isPatroling == true)
        {
            enemyReferences.navMeshagent.speed = walkSpeed;
        }
        else if (isPatroling == false)
        {
            enemyReferences.navMeshagent.speed = runSpeed;
        }

    }

    private void CheckIfDead()
    {
        if (isDead == true)
        {
            Debug.Log("Check if dead çalışıyor");
            enemyReferences.animator.SetBool("isDead", true);
            Debug.Log("Animasyon oynanması lazım");
            StartCoroutine(DestroyCanavar());
        }
    }

    IEnumerator DestroyCanavar()
    {
        Debug.Log("IENUmarator calisiyor");
        yield return new WaitForSeconds(4);
        Destroy(gameObject);


    }

}
