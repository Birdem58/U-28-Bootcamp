using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MertCanavrTrigger : MonoBehaviour
{

    [SerializeField] private UnityEvent _mertCanavarTriggerduvar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mertCanavarTriggerduvar.Invoke();

        }
    }
}
