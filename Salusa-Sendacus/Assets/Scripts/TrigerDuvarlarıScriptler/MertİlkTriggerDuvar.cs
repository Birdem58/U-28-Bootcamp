using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MertİlkTriggerDuvar : MonoBehaviour
{
    [SerializeField] private UnityEvent _mertilkTriggerduvar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mertilkTriggerduvar.Invoke();

        }
    }
}
