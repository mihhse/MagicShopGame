using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;



public class Interactor : MonoBehaviour
{

    private InventoryManager inventoryManager;
    [SerializeField] private TextMeshProUGUI interactionText;
    [SerializeField] private float interactionRange;
    [SerializeField] private Transform orientation;

    private void Start()
    {
        inventoryManager = GameObject.Find("Canvas").GetComponent<InventoryManager>();

    }
    private void Update()
    {
        //INTERACTION
        if (Physics.Raycast(orientation.position, orientation.forward, out RaycastHit hit, interactionRange))
        {
            // ITEM
            if (hit.transform.TryGetComponent(out Item item))
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = ("Press F to pick up");

                if (Input.GetButtonDown("Interaction"))
                {
                    Debug.Log("interact");
                    item.GetComponent<Item>().Interact();
                }
            }

            // CRAFTED ITEM
            else if (hit.transform.TryGetComponent(out CraftedItem craftedItem))
            {
                interactionText.gameObject.SetActive(true);
                interactionText.text = ("Press F to pick up");

                if (Input.GetButtonDown("Interaction"))
                {
                    Debug.Log("interact");
                    craftedItem.GetComponent<CraftedItem>().Interact();
                }
            }

            // CRAFTING TABLE
            else if (hit.transform.parent.TryGetComponent(out CraftingTable table))
            {
                    interactionText.gameObject.SetActive(true);
                    interactionText.text = ("Press F to craft");

                    if (Input.GetButtonDown("Interaction"))
                    {
                        Debug.Log("interact");
                        table.GetComponent<CraftingTable>().Interact();
                    }
            }

            // GATHERER
            else if (hit.transform.parent.TryGetComponent(out TheGatherer gatherer))
            {
                if (!gatherer.GetComponent<TheGatherer>().tableOccupied)
                {
                    interactionText.gameObject.SetActive(true);
                    interactionText.text = ("Press F to get items");

                    if (Input.GetButtonDown("Interaction"))
                    {
                        Debug.Log("interact");
                        gatherer.GetComponent<TheGatherer>().Interact();
                    }
                }
            }
            else
                interactionText.gameObject.SetActive(false);
        }
        else
            interactionText.gameObject.SetActive(false);
    }
}
