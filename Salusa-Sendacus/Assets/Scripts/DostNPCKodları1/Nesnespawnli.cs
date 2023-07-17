using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nesnespawnli : MonoBehaviour
{
    public GameObject Nesne;
    public GameObject Nesne2;
    public GameObject Nesne3;


    private void Start()
    {



    }
    private void Awake()
    {
        Nesne.SetActive(false);
        Nesne2.SetActive(false);
        Nesne3.SetActive(false);
    }

    private void OnTriggerEnter(Collider Razor)
    {
        if (Razor.gameObject.CompareTag("Player"))
        {
            Nesne.SetActive(true);
            Nesne2.SetActive(true);
            Nesne3.SetActive(true);
        }
    }
}
