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

        if (Physics.Raycast(orientation.position, orientation.forward, out RaycastHit hit, interactionRange))
        {
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
            }
            else
                interactionText.gameObject.SetActive(false);
    }
}
