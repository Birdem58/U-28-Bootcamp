using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;



public class AILocomotion : MonoBehaviour
{
    public Transform playerTransform;
    public float maxTime = 1.0f;
    public float maxDistance = 1.0f;
    float distanceBetween;

    public float detectDistance;

    public float attackDistance = 1.0f;

    private float timer = 0.0f;
    NavMeshAgent agent;

    Animator animator;
    UIHealtbar healtBar;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        healtBar = GetComponentInChildren<UIHealtbar>();
        distanceBetween = Vector3.Distance(transform.position, playerTransform.position);
    }

    // Update is called once per frame
    void Update()
    {
        distanceBetween = Vector3.Distance(transform.position, playerTransform.position);
        if (distanceBetween > detectDistance)
        {
            healtBar.gameObject.SetActive(false);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }


        else if (distanceBetween < detectDistance)
        {
            healtBar.gameObject.SetActive(true);
            bool inAttackRange = Vector3.Distance(transform.position, playerTransform.position) <= attackDistance;
            timer -= Time.deltaTime;
            if (timer < 0.0f)
            {
                agent.destination = playerTransform.position;
                timer = maxTime;

            }
            LookAtTarget();
            animator.SetBool("isAttack", inAttackRange);
            animator.SetFloat("Speed", agent.velocity.magnitude);
        }
    }
    private void LookAtTarget()
    {
        Vector3 lookPos = playerTransform.position - transform.position;
        lookPos.y = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 0.2f);

    }
}
