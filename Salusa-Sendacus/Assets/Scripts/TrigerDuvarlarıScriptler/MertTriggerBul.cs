using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MertTriggerBul : MonoBehaviour
{
    [SerializeField] private UnityEvent _mertBulTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mertBulTrigger.Invoke();

        }
    }
}
