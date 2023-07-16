using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class ChrisScript : MonoBehaviour
{
    public AudioClip AstraVeChrisSesi;
    public float Timer = 45;
    public Transform ChrisTransformu;
    private bool fg = false;
    public Transform Bosluk;
    public GameObject Colliderdegis;
    private Animator Animatör;
    

    [SerializeField] UnityEvent _ChrisKonusuyor;

    private void Start()
    {
        Colliderdegis.GetComponent<BoxCollider>().enabled = true;
        Animatör = GetComponent<Animator>();
        
    }
    





    private void OnTriggerEnter(Collider LiWei)
    {
        if (LiWei.gameObject.CompareTag("Player") && !fg)
        {
            fg = true;
            GetComponent<AudioSource>().PlayOneShot(AstraVeChrisSesi);
            //GetComponent<BoxCollider>().center = new Vector3(0, -20, 0);
            StartCoroutine(StartTimer());
        }
        

    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(30);
        _ChrisKonusuyor.Invoke();
        yield return new WaitForSeconds(Timer);
        Animatör.SetBool("fg", true);
        ChrisTransformu.position = Bosluk.position;
        ChrisTransformu.rotation = Quaternion.Euler(0, 270, 0);
        


    }
}

