using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UcanDabbeScripti1 : MonoBehaviour
{
    public Transform Oyuncu;

    public Vector3 CevirmeAcisi;

    public float TakipUzaklýðý;

    public float Hýz;
    private void Awake()
    {
        Oyuncu = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        FollowAstra();
    }

    private void FollowAstra()
    {
        //Oyuncuya baktýðý yer.
        transform.LookAt(Oyuncu.position);
        transform.rotation *= Quaternion.Euler(CevirmeAcisi);

        //Burada Astra'ya hareket edecek.
        if(Vector3.Distance(transform.position , Oyuncu.position) >= TakipUzaklýðý)
        {
            transform.Translate(transform.forward * Time.deltaTime * Hýz);
        }
        else
        {
            transform.RotateAround(Oyuncu.position, Vector3.forward, Time.deltaTime * Hýz * Random.Range(0.2f , 3f));
            transform.Translate(transform.up * Time. deltaTime);
        }
        
    }
}
