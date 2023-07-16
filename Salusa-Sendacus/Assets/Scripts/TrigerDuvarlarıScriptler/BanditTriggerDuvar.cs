using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class BanditTriggerDuvar : MonoBehaviour
{

    [SerializeField] private UnityEvent _BanditTriggerDuvar;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _BanditTriggerDuvar.Invoke();

        }
    }
}
