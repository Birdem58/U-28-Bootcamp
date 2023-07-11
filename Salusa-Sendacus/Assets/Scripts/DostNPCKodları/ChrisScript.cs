using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrisScript : MonoBehaviour
{
    public AudioClip AstraVeChrisSesi;
    public float Timer = 45;
    public Transform ChrisTransformu;
    private bool Tetik = false;
    private Animator Animatör;

    private void Start()
    {
        Animatör = GetComponent<Animator>();
    }
    
    

    private void OnTriggerEnter(Collider LiWei)
    {
        if (LiWei.gameObject.CompareTag("Player") && !Tetik)
        {
            Tetik = true;
            GetComponent<AudioSource>().PlayOneShot(AstraVeChrisSesi);
            GetComponent<BoxCollider>().center = new Vector3(0, -20, 0);
            StartCoroutine(StartTimer());
        }

    }
    
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(Timer);

        ChrisTransformu.position = new Vector3(434 , 360.7f , 518);
        print("GTX");
        Animatör.SetBool("TimerOver", true);
        print("RTX");
    }
}

