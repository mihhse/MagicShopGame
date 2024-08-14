using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] public Sprite itemSprite;
    public IngredientType ingredientType = new IngredientType();
    public string ingredientTypeString;
    [SerializeField] private RecipeSO recipeSO;

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

    private void Awake()
    {
        ingredientTypeString = ingredientType.ToString();
    }

    internal void Interact()
    {
        inventoryManager.AddItem(itemName, itemSprite, ingredientTypeString, recipeSO);
        Destroy(gameObject);
    }
}
