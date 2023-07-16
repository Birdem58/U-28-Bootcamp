using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChrisCanavarTriggerDuvarı : MonoBehaviour
{
    [SerializeField] private UnityEvent _ChrisCanavarTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _ChrisCanavarTrigger.Invoke();

        }
    }
}
