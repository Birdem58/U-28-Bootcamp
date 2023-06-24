using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kristal : MonoBehaviour
{

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>

    private void OnTriggerEnter(Collider other)
    {
        PlayerInventory playerInventory = other.GetComponent<PlayerInventory>();
        if (playerInventory != null)
        {
            playerInventory.ToplananKristal();
            gameObject.SetActive(false);
        }
    }


}
