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
    [SerializeField] private string primaryType;
    [SerializeField] private string secondaryType;

    [HideInInspector] public bool isFull;
    public bool itemSlotIsSelected;
    public GameObject selectedSlot;

    // ITEM SLOT
    [SerializeField] private TextMeshProUGUI quantityText;
    [SerializeField] private Image itemImage;

    public void AddItem(string itemName, int quantity, Sprite itemSprite, string primaryType, string secondaryType)
    {
        this.itemName = itemName;
        this.quantity = quantity;
        this.itemSprite = itemSprite;
        this.primaryType = primaryType;
        this.secondaryType = secondaryType;

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
