using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MertTriggerikinci : MonoBehaviour
{

    [SerializeField] private UnityEvent _mertIkinciTriggerduvar;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mertIkinciTriggerduvar.Invoke();

        }
    }
}
