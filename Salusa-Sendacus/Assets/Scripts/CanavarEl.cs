using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanavarEl : MonoBehaviour
{
    public BasicAI basicAI;
    public ThirdPersonHealthManager thirdPersonHealthManager;


    // Start is called before the first frame update
    void Start()
    {
        thirdPersonHealthManager = GameObject.FindGameObjectWithTag("Player").GetComponent<ThirdPersonHealthManager>();
        basicAI = GameObject.FindGameObjectWithTag("Canavar").GetComponent<BasicAI>();
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
