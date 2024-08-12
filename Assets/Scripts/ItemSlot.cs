using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    // ITEM DATA
    [SerializeField] private string itemName;
    [SerializeField] int quantity;
    [SerializeField] Sprite itemSprite;
    [HideInInspector] public bool isFull;
    public bool itemSlotIsSelected;
    public GameObject selectedSlot;

    // ITEM SLOT
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Image itemImage;

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        isFull = true;

        quantityText.text = quantity.ToString();
        quantityText.enabled = true;
        itemImage.sprite = itemSprite;
    }

    public void SelectItemSlot()
    {
        itemSlotIsSelected = true;
        selectedSlot.SetActive(true);
    }

}
