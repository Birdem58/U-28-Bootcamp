using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChrisKonusmaTriggerDuvarı : MonoBehaviour
{
    [SerializeField] private UnityEvent _chrisKonusmaTrigger;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _chrisKonusmaTrigger.Invoke();

        }
    }

}
