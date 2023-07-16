using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LiweiTriggerDuvar : MonoBehaviour
{
    [SerializeField] private UnityEvent _liWeiDuvarTrigger;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _liWeiDuvarTrigger.Invoke();

        }
    }
}
