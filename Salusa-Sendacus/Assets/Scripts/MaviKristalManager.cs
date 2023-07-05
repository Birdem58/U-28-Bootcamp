using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MaviKristalManager : MonoBehaviour
{
    [SerializeField] private UnityEvent _collectedHasar;
    // Start is called before the first frame update
    void Start()
    {
        _collectedHasar.AddListener(GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonShooterController>().ChargeHasar);

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.gameObject)
        {
            _collectedHasar.Invoke();
            Destroy(gameObject);
        }
    }
}
