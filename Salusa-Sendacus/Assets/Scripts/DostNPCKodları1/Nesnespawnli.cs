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
        if (Nesne != null)
        {
            Nesne.SetActive(false);
        }

        if (Nesne2 != null)
        {
            Nesne2.SetActive(false);
        }
        if (Nesne3 != null)
        {
            Nesne3.SetActive(false);
        }


    }

    private void OnTriggerEnter(Collider Razor)
    {
        if (Razor.gameObject.CompareTag("Player"))
        {
            if (Nesne != null)
            {
                Nesne.SetActive(true);
            }

            if (Nesne2 != null)
            {
                Nesne2.SetActive(true);
            }
            if (Nesne3 != null)
            {
                Nesne3.SetActive(true);
            }

        }
    }
}
