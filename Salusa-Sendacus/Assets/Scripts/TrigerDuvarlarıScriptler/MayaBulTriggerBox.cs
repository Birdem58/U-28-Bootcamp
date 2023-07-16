using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MayaBulTriggerBox : MonoBehaviour
{
    [SerializeField] private UnityEvent _mayaBuldukBox;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _mayaBuldukBox.Invoke();

        }
    }
}
