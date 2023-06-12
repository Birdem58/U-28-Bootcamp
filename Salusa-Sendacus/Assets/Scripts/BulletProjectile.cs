using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletProjectile : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    private Rigidbody bulletRigidbody;


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

    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
}
