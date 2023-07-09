using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenerKodlari : MonoBehaviour
{
    public GameObject ElFeneri;
    private bool Işık = false;

    private void Start()
    {
        ElFeneri.gameObject.SetActive(false);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            if(Işık == false)
            {
                ElFeneri.gameObject.SetActive(true);
                Işık = true;
            }
            else
            {
                ElFeneri.gameObject.SetActive(false);
                Işık = false;
            }
        }
        
    }
}
