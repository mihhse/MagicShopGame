using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CraftingItemSlot : MonoBehaviour, IDropHandler
{
    [SerializeField] private string itemName;
    [SerializeField] Sprite itemSprite;
    [SerializeField] public string ingredientTypeString;
    [SerializeField] private bool isRecipeSlot;
    [SerializeField] private RecipeSO recipeSO;
    [SerializeField] private GameObject craftingUI;
    [SerializeField] public GameObject expectedIngredientImage;

    public ExpectedIngredient expectedIngredient = new ExpectedIngredient();
    public string expectedIngredientString;

    [HideInInspector] public bool isFull;

    //REFERENCES
    [SerializeField] private GameObject ItemImage;
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
                GameObject dropped = eventData.pointerDrag; // new image
                DragDrop dragDrop = dropped.GetComponent<DragDrop>(); // dropped image's drag drop component

                dragDrop.parentAfterDrag = transform;
                Debug.Log("Dropped");
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;

                if (dragDrop.ingredientTypeString.ToString() == expectedIngredientString)
                {
                    recipeSO = dragDrop.recipeSO;
                    Debug.Log("Recipe inserted");
                    craftingUI.GetComponent<CraftingUI>().RecieveCraftingRecipe(recipeSO);
                }
        }
    }

    private void Start()
    {
        expectedIngredientString = expectedIngredient.ToString();
    }
    private void Update()
    {
        if (transform.childCount > 0)
            isFull = true;
        else isFull = false;
    }

    public void AddItem(string itemName, Sprite itemSprite, string ingredientTypeString, RecipeSO recipeSO)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        isFull = true;
        this.ingredientTypeString = ingredientTypeString;
        this.recipeSO = recipeSO;

        GameObject itemImage = Instantiate(ItemImage);
        itemImage.transform.SetParent(transform);

        itemImage.GetComponent<Image>().sprite = itemSprite;
        itemImage.GetComponent<DragDrop>().ReceiveItemData(itemName, itemSprite, ingredientTypeString, recipeSO);

        EmptySlot();
    }

    public enum ExpectedIngredient
    {
        None,
        Wood,
        Metal,
        Crystal,
        Recipe
    };

    public void ReceiveItemData(string itemName, Sprite itemSprite, string ingredientTypeString, RecipeSO recipeSO)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.ingredientTypeString = ingredientTypeString;
        this.recipeSO = recipeSO;
    }

    public void EmptySlot()
    {
        itemName = null;
        itemSprite = null;
        ingredientTypeString = null;
        recipeSO = null;
    }
}
