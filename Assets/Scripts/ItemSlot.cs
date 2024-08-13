using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    // ITEM DATA
    [SerializeField] private string itemName;
    [SerializeField] Sprite itemSprite;

    [HideInInspector] public bool isFull;
    public bool itemSlotIsSelected;

    // ITEM SLOT
    [SerializeField] private Image itemImage;
    private Color selectedItemSlotColor = new Color32(255, 80, 80, 150);

    public void AddItem(string itemName, Sprite itemSprite)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        isFull = true;

        itemImage.sprite = itemSprite;
    }

    public void SelectItemSlot()
    {
        itemSlotIsSelected = true;
        gameObject.GetComponent<Image>().color = selectedItemSlotColor;
    }

    private void Update()
    {
        if (isFull)
        {
            itemImage.gameObject.SetActive(true);
        }
        else
            itemImage.gameObject.SetActive(false);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            Debug.Log("Dropped");
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
        }
    }
}
