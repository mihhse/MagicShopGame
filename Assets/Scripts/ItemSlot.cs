using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using static UnityEditor.Progress;

public class ItemSlot : MonoBehaviour, IDropHandler
{
    // ITEM DATA
    [SerializeField] private string itemName;
    [SerializeField] Sprite itemSprite;
    [SerializeField] private string ingredientTypeString;
    [SerializeField] private RecipeSO recipeSO;

    public bool isFull;
    public bool itemSlotIsSelected;

    // ITEM SLOT
    [SerializeField] private GameObject ItemImage;
    private Color selectedItemSlotColor = new Color32(255, 80, 80, 150);

    public void AddItem(string itemName, Sprite itemSprite, string ingredientTypeString, RecipeSO recipeSO)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        isFull = true;
        this.ingredientTypeString = ingredientTypeString;
        this.recipeSO = recipeSO;

        GameObject itemImage = Instantiate (ItemImage);
        itemImage.transform.SetParent(transform);

        itemImage.GetComponent<Image>().sprite = itemSprite;
        itemImage.GetComponent<DragDrop>().ReceiveItemData(itemName, itemSprite, ingredientTypeString, recipeSO);
        EmptySlot();
    }

    public void SelectItemSlot()
    {
        itemSlotIsSelected = true;
        gameObject.GetComponent<Image>().color = selectedItemSlotColor;
    }

    private void Update()
    {
        if (transform.childCount > 0)
            isFull = true;
        else isFull = false;
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject dropped = eventData.pointerDrag; // item image
            DragDrop dragDrop = dropped.GetComponent<DragDrop>(); // dropped image's drag drop component

            dragDrop.parentAfterDrag = transform;
            Debug.Log("Dropped");
            eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
        }
    }


    public void EmptySlot()
    {
        itemName = null;
        itemSprite = null;
        ingredientTypeString = null;
        recipeSO = null;
    }

    public void ReceiveItemData(string itemName, Sprite itemSprite, string ingredientTypeString, RecipeSO recipeSO)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.ingredientTypeString = ingredientTypeString;
        this.recipeSO = recipeSO;
    }
}
