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
        thirdPersonShooterController = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonShooterController>();
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
        basicAI = GameObject.FindGameObjectWithTag("Canavar").GetComponent<BasicAI>();

        if (basicAI != null && thirdPersonShooterController != null)
        {
            if (other.CompareTag("Canavar"))
            {
                basicAI.canavarCan -= thirdPersonShooterController.Hasar;
                Debug.Log(thirdPersonShooterController.Hasar);
                Debug.Log("hasar da alıyor canavar");
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);

            }
        }
    }
}
