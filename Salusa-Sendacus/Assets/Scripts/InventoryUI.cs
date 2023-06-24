using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    private TextMeshProUGUI kristalText;
    // Start is called before the first frame update
    void Start()
    {
        kristalText = GetComponent<TextMeshProUGUI>();
    }

    public void UpdateKristalText(PlayerInventory playerInventory)
    {
        kristalText.text = playerInventory.KristalSayisi.ToString();
    }
}
