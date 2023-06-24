using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInventory : MonoBehaviour
{
    public int KristalSayisi { get; private set; }

    public UnityEvent<PlayerInventory> OnToplananKristal;


    public void ToplananKristal()
    {
        KristalSayisi++;
        OnToplananKristal.Invoke(this);
    }

}
