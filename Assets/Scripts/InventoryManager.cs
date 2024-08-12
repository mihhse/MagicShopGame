using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{

    public ItemSlot[] itemSlot;
    [SerializeField] private float selectedSlot = 0;
    [SerializeField] private float itemSlotMax;

    public void AddItem(string itemName, int quantity, Sprite itemSprite)
    {
        Debug.Log("Picked Up");
        for (int i = 0; i < itemSlot.Length; i++)
        {
            if (itemSlot[i].isFull == false)
            {
                itemSlot[i].AddItem(itemName, quantity, itemSprite);
                return;
            }
        }
    }

    private void Start()
    {
        itemSlot[0].itemSlotIsSelected = true;
        UpdateSelectedSlot();
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0f) // scrolling up
        {
                selectedSlot++;
            if (selectedSlot >= itemSlotMax)
                selectedSlot = 0;
            UpdateSelectedSlot();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0f) // scrolling down
        {
                selectedSlot--;
            if (selectedSlot <= -1)
                selectedSlot = itemSlotMax-1;
            UpdateSelectedSlot();
        }
    }

    private void UpdateSelectedSlot()
    {
        DeselectAllSlots();
        itemSlot[((int)selectedSlot)].GetComponent<ItemSlot>().SelectItemSlot();
    }

    public void DeselectAllSlots()
    {
        for (int i = 0; i < itemSlot.Length; i++)
        {
            itemSlot[i].itemSlotIsSelected = false;
            itemSlot[i].selectedSlot.SetActive(false);
        }
    }
}
