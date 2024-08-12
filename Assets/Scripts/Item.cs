using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private string itemName;
    [SerializeField] private int quantity;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] private string primaryType;
    [SerializeField] private string secondoryType;

    private InventoryManager inventoryManager;

    private void Start()
    {
        inventoryManager = GameObject. Find("Canvas") .GetComponent<InventoryManager>();
    }

    private void Update()
    {
        
    }

    internal void Interact()
    {
        inventoryManager.AddItem(itemName, quantity, itemSprite, primaryType, secondoryType);
        Destroy(gameObject);
    }
}
