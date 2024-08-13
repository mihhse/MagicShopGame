using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftingTable : MonoBehaviour
{
    [SerializeField] private GameObject craftingUI;
    [SerializeField] private GameObject itemToCraft;
    [SerializeField] private GameObject spawnLocation;
    [SerializeField] private GameObject cursor;
    internal void Interact()
    {
        craftingUI.SetActive(true);
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        cursor.SetActive(false);
    }

    public void CloseCraftingUI()
    {
        craftingUI.SetActive(false);
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Cursor.visible = true;
    }

    public void Craft()
    {
        GameObject craftedItem = Instantiate(itemToCraft, spawnLocation.transform.position, spawnLocation.transform.rotation);
        craftedItem.GetComponent<CraftedItem>().craftedItemOptionalParts[0].SetActive(false);
        CloseCraftingUI();
    }
}
