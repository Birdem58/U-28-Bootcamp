using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIAttack : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
[SerializeField] private AudioClip _canavarHasar;


    [SerializeField] private UnityEvent _damagePlayer;

    public int hasar = 5;
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
            audioSource.PlayOneShot(_canavarHasar);
            _damagePlayer.Invoke();
        }
    }
}
