using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanavarEl : MonoBehaviour
{
    public BasicAI basicAI;
    public ThirdPersonHealthManager thirdPersonHealthManager;


    void Awake()
    {
        thirdPersonHealthManager = GetComponent<ThirdPersonHealthManager>();
        basicAI = GetComponent<BasicAI>();
    }
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
                Debug.Log("HasarVeriyorCAnavar");
                thirdPersonHealthManager.currentHealth -= basicAI.canavarHasar;
            }
        }
    }
}
