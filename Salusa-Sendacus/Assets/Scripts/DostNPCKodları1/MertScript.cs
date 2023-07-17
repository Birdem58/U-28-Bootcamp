using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class MertScript : MonoBehaviour
{
    public AudioClip AstraVeMertSesi;
    public float Timer = 45;
    public Transform MertTransformu;
    private bool gtx = false;
    private Animator Animator;
    public GameObject Colliderdegis;
    public Transform Bosluk;
    [SerializeField] private UnityEvent _mertKonusmaSonrasi;



    private void Start()
    {
        Animator = GetComponent<Animator>();
        Colliderdegis.GetComponent<BoxCollider>().enabled = true;

    }




    private void OnTriggerEnter(Collider LiWei)
    {
        if (LiWei.gameObject.CompareTag("Player") && !gtx)
        {
            gtx = true;
            GetComponent<AudioSource>().PlayOneShot(AstraVeMertSesi);
            GetComponent<BoxCollider>().center = new Vector3(0, -20, 0);
            _mertKonusmaSonrasi.Invoke();
            StartCoroutine(StartTimer());

        }

    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(Timer);

        MertTransformu.position = Bosluk.position;
        Animator.SetBool("gtx", true);
        Colliderdegis.GetComponent<BoxCollider>().enabled = true;

    }
}
