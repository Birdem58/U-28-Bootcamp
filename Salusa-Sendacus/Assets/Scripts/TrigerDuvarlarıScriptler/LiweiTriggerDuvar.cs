using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LiweiTriggerDuvar : MonoBehaviour
{
    [SerializeField] private UnityEvent _liWeiDuvarTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _liWeiDuvarTrigger.Invoke();

        }
    }
}
