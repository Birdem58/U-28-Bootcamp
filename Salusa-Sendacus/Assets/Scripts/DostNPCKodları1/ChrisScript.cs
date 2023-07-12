using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisScript : MonoBehaviour
{
    public AudioClip AstraVeChrisSesi;
    public float Timer = 45;
    public Transform ChrisTransformu;
    private bool Tetik = false;
    
    

    
    
    

    private void OnTriggerEnter(Collider LiWei)
    {
        if (LiWei.gameObject.CompareTag("Player") && !Tetik)
        {
            Tetik = true;
            GetComponent<AudioSource>().PlayOneShot(AstraVeChrisSesi);
            GetComponent<BoxCollider>().center = new Vector3(0, -20, 0);
            StartCoroutine(StartTimer());
        }
        if (Timer <= 0)
        {
            
            print("GTX");
            
        }

    }
    
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(Timer);

        ChrisTransformu.position = new Vector3(-1000 , -1000 , -1000); //434 360.7 518
        
        
        
    }
}

