using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MayaKoyBul : MonoBehaviour
{
    [SerializeField] private UnityEvent _mayaBulTriggerduvar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mayaBulTriggerduvar.Invoke();

        }
    }
}
