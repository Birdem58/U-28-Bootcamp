using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class LiWeiScript : MonoBehaviour
{
    public AudioClip AstraVeLiWeiSesi;
    public float Timer = 45;
    public Transform LiWeiTransformu;
    public Animator Animator;
    [SerializeField] private UnityEvent _liWeiKonusma;
    [SerializeField] private UnityEvent _liWeiBilgi;

    private bool Tetik = false;

    private void OnTriggerEnter(Collider LiWei)
    {
        if (LiWei.gameObject.CompareTag("Player") && !Tetik)
        {
            Tetik = true;
            GetComponent<AudioSource>().PlayOneShot(AstraVeLiWeiSesi);
            GetComponent<CapsuleCollider>().center = new Vector3(0, -20, 0);
            _liWeiKonusma.Invoke();
            StartCoroutine(KonusmaSonrasi());
            StartCoroutine(StartTimer());

        }


    }
    /*private void Update()
    {
        if(Timer > 0)
        {
            Timer -= Time.deltaTime;
        }
        else
        {
            LiWeiTransformu.position = new Vector3(460, 361 ,522);
        }
    }*/

    IEnumerator KonusmaSonrasi()
    {
        yield return new WaitForSeconds(25);
        _liWeiBilgi.Invoke();
    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(Timer);

        LiWeiTransformu.position = new Vector3(-1000, -1000, -1000);  //438 , 360.3f , 522


    }
}
/*public class ChrisScript : MonoBehaviour
{
    public AudioClip AstraVeChrisesi;
    public float Timer = 45;
    public Transform ChrisTransformu;
    private bool Tetik = false;

    private void OnTriggerEnter(Collider Chris)
    {
        if (Chris.gameObject.CompareTag("Player") && !Tetik)
        {
            Tetik = true;
            GetComponent<AudioSource>().PlayOneShot(AstraVeChrisesi);
            GetComponent<BoxCollider>().center = new Vector3(0, -20, 0);
            StartCoroutine(StartTimer());
        }

    }
    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(Timer);

        ChrisTransformu.position = new Vector3(460, 361, 522);
    }
}*/

