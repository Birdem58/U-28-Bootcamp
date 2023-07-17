using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nesnespawnlises : MonoBehaviour
{
    public AudioClip Disturbed;
    public GameObject Kup2;
    private bool RTX = true;

    private void Update()
    {

    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && (RTX == true))
        {
            GetComponent<AudioSource>().PlayOneShot(Disturbed);
            RTX = false;
        }
    }
}
