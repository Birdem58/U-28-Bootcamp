using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody bulletRigidbody;
    public ThirdPersonShooterController thirdPersonShooterController;

    public BasicAI basicAI;
    [SerializeField] private float deleteTime = 5f;


    private void Awake()
    {
        bulletRigidbody = GetComponent<Rigidbody>();



    }
    private void Start()
    {
        bulletRigidbody.velocity = transform.forward * speed;


    }
    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, deleteTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (basicAI != null && thirdPersonShooterController != null)
        {
            if (other.CompareTag("Canavar"))
            {
                basicAI.canavarCan -= thirdPersonShooterController.Hasar;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);

            }
        }
    }
}
