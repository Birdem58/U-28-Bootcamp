using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LiWeiScript : MonoBehaviour
{
    public AudioClip AstraVeLiWeiSesi;
    public float Timer = 35;
    public Transform LiWeiTransformu;
    private Animator Animatör;
    public GameObject Colliderdegis;
    [SerializeField] private UnityEvent _liWeiKonusma;
    [SerializeField] private UnityEvent _liWeiBilgi;
    public Transform Bosluk;
    private bool asd = false;
    

    private void Start()
    {
        Animatör = GetComponent<Animator>();
        Colliderdegis.GetComponent<SphereCollider>().enabled = true;
        
    }

    

    private void OnTriggerEnter(Collider LiWei)
    {
        if (LiWei.gameObject.CompareTag("Player") && !asd)
        {
            asd = true;
            GetComponent<AudioSource>().PlayOneShot(AstraVeLiWeiSesi);
            //GetComponent<CapsuleCollider>().center = new Vector3(0, -20, 0);
            _liWeiKonusma.Invoke();
            StartCoroutine(KonusmaSonrasi());
            StartCoroutine(StartTimer());
            Colliderdegis.GetComponent<SphereCollider>().enabled = false;
        }


    }
    

    IEnumerator KonusmaSonrasi()
    {
        yield return new WaitForSeconds(35);
        _liWeiBilgi.Invoke();
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(Timer);

        LiWeiTransformu.position = Bosluk.position;
        LiWeiTransformu.rotation = Quaternion.Euler(0, 90, 0);
        
        Animatör.SetBool("asd", true);
        Colliderdegis.GetComponent<SphereCollider>().enabled = true;


    }
}


