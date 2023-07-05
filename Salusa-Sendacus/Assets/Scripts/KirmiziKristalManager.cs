using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class KirmiziKristalManager : MonoBehaviour
{

    [SerializeField] private UnityEvent _collectedCan;
    
    // Start is called before the first frame update
    void Start()
    {
        _collectedCan.AddListener(GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonHealthManager>().CanBarRegen);

    }

    // Update is called once per frame
    void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject)
        {
            _collectedCan.Invoke();
            
            Destroy(gameObject);
            
        }
    }
}
