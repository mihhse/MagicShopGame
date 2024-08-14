using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftedItem : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] public MeshRenderer[] craftedItemMaterialSlots;
    [SerializeField] public GameObject[] craftedItemOptionalParts;
    private string ingredientTypeString;
    [SerializeField] private RecipeSO recipeSO;

    [SerializeField] private Recipe recipe;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();
    }

    private void Update()
    {

    }

    internal void Interact()
    {
        inventoryManager.AddItem(itemName, itemSprite, ingredientTypeString, recipeSO);
        Destroy(gameObject);
    }
}
