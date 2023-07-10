using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanavarEl : MonoBehaviour
{
    public BasicAI basicAI;
    public ThirdPersonHealthManager thirdPersonHealthManager;

    GameObject Player;




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
        if (basicAI != null && thirdPersonHealthManager != null)
        {
            if (other.CompareTag("Player"))
            {
                thirdPersonHealthManager.currentHealth -= basicAI.canavarHasar;
            }
        }
    }
}
