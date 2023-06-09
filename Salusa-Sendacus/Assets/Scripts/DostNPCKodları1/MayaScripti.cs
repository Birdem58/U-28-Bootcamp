using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayaScripti : MonoBehaviour
{
    public AudioClip AstraVeMayaSesi;
    public float Timer = 45;
    public Transform MayaTransformu;
    private bool Tetik = false;

    private void OnTriggerEnter(Collider LiWei)
    {
        if (LiWei.gameObject.CompareTag("Player") && !Tetik)
        {
            Tetik = true;
            GetComponent<AudioSource>().PlayOneShot(AstraVeMayaSesi);
            GetComponent<BoxCollider>().center = new Vector3(0, -20, 0);
            StartCoroutine(StartTimer());
        }

    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(Timer);

        MayaTransformu.position = new Vector3(-1000,-1000,-1000);
    }
}
