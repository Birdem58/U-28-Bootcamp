using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class KristalManager : MonoBehaviour
{
    [SerializeField] private UnityEvent _collectedCharge;



    private void Start()
    {
        _collectedCharge.AddListener(GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonShooterController>().ChargeBarRegen);
    }

    void Update()
    {



    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject)
        {
            _collectedCharge.Invoke();
            Destroy(gameObject);
        }
    }

    public void test()
    {
        Debug.Log("teest fonksyonu kristal manager içinde");
    }
}
