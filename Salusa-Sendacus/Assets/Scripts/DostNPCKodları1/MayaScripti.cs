using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayaScripti : MonoBehaviour
{
    public AudioClip AstraVeMayaSesi;
    public float Timer = 45;
    public Transform MayaTransformu;
    private bool rt = false;
    public Transform Bosluk;
    private Animator Animator;
    public GameObject Colliderdegis;
    
    private void Start()
    {
        Animator = GetComponent<Animator>();
        Colliderdegis.GetComponent<BoxCollider>().enabled = true;
        
    }
    

    private void OnTriggerEnter(Collider LiWei)
    {
        if (LiWei.gameObject.CompareTag("Player") && !rt)
        {
            rt = true;
            GetComponent<AudioSource>().PlayOneShot(AstraVeMayaSesi);
            GetComponent<BoxCollider>().center = new Vector3(0, -20, 0);
            StartCoroutine(StartTimer());
        }

    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(Timer);

        MayaTransformu.position = Bosluk.position;
        MayaTransformu.rotation = Quaternion.Euler(0, 270, 0);
        
        Animator.SetBool("rt", true);
        Colliderdegis.GetComponent<BoxCollider>().enabled = true;
    }
}
