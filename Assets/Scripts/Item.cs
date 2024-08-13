using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;
    public IngredientType ingredientType = new IngredientType();
    private string ingredientTypeString;

    private InventoryManager inventoryManager;

    public enum IngredientType
    {
        None,
        Wood,
        Metal,
        Crystal,
        Recipe
    };

    private void Start()
    {
        inventoryManager = GameObject. Find("Canvas") .GetComponent<InventoryManager>();
        ingredientTypeString = ingredientType.ToString();
    }

    private void Update()
    {
        
    }

    internal void Interact()
    {
        inventoryManager.AddItem(itemName, itemSprite, ingredientTypeString);
        Destroy(gameObject);
    }
}
