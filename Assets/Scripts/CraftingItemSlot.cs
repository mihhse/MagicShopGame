using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftingItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private string itemName;
    [SerializeField] Sprite itemSprite;
    [SerializeField] public string itemSlotIngredientTypeString;

    public ExpectedIngredient expectedIngredient = new ExpectedIngredient();

    [HideInInspector] public bool isFull;

    //REFERENCES
    [SerializeField] private Image itemImage;
    [SerializeField] InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
                GameObject dropped = eventData.pointerDrag;
                DragDrop dragDrop = dropped.GetComponent<DragDrop>();
                dragDrop.parentAfterDrag = transform;
                Debug.Log("Dropped");
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;

            if (dropped.GetComponent<DragDrop>().DDingredientType == expectedIngredient.ToString())
            {
                Debug.Log("Recipe inserted");
            }
        }
    }

    public enum ExpectedIngredient
    {
        None,
        Wood,
        Metal,
        Crystal,
        Recipe
    };
}
