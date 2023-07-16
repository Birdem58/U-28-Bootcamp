using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MayaVadiİlkTriggerDuvarı : MonoBehaviour
{
    [SerializeField] private UnityEvent _mayailkTriggerduvar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mayailkTriggerduvar.Invoke();

        }
    }
}
