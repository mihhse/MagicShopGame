using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragDrop : MonoBehaviour,IBeginDragHandler,IEndDragHandler, IDragHandler
{
    [SerializeField] private Canvas canvas;
    private RectTransform rectTransform;
    public CanvasGroup canvasGroup;
    public Image DDimage;
    public string DDingredientType;


    public GameObject originalItemSlot;


    [HideInInspector] public Transform parentAfterDrag;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup= GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //visuals
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

        //get information from original item slot
        originalItemSlot = eventData.pointerDrag.gameObject; // original item is set to game object of the item slot below
        GetComponent<DragDrop>().DDingredientType = GetComponentInParent<ItemSlot>().itemSlotIngredientTypeString;  // get ingredient type from item
        GetComponent<DragDrop>().DDingredientType = GetComponentInParent<CraftingItemSlot>().itemSlotIngredientTypeString;  // get ingredient type from  crafted item


        // change parent
        parentAfterDrag = transform.parent;
        transform.SetParent(transform.root);
        transform.SetAsLastSibling();
        DDimage.raycastTarget = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //visuals
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // change parent back to original item slot
        transform.SetParent(parentAfterDrag);
        DDimage.raycastTarget = true;
    }
}
