using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MayaVadiİkinciTriggerDuvarı : MonoBehaviour
{
    [SerializeField] private UnityEvent _mayaikinciTriggerduvar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mayaikinciTriggerduvar.Invoke();

        }
    }
}

