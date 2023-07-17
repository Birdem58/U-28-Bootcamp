using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class SonObjectiveTrigger : MonoBehaviour
{
    [SerializeField] private UnityEvent _SonObj;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _SonObj.Invoke();

        }
    }
}
