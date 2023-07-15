using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MertScript : MonoBehaviour
{
    public AudioClip AstraVeMertSesi;
    public float Timer = 45;
    public Transform MertTransformu;
    private bool Tetik = false;

    private void OnTriggerEnter(Collider LiWei)
    {
        if (LiWei.gameObject.CompareTag("Player") && !Tetik)
        {
            Tetik = true;
            GetComponent<AudioSource>().PlayOneShot(AstraVeMertSesi);
            GetComponent<BoxCollider>().center = new Vector3(0, -20, 0);
            StartCoroutine(StartTimer());
        }

    }

    IEnumerator StartTimer()
    {
        yield return new WaitForSeconds(Timer);

        MertTransformu.position = new Vector3(-1000,-1000,-1000);
    }
}
