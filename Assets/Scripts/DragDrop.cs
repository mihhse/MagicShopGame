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


    [HideInInspector] public Transform parentAfterDrag;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup= GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
        GetComponent<DragDrop>().DDingredientType = GetComponentInParent<ItemSlot>().itemSlotIngredientTypeString;
        GetComponent<DragDrop>().DDingredientType = GetComponentInParent<CraftingItemSlot>().itemSlotIngredientTypeString;
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
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        transform.SetParent(parentAfterDrag);
        DDimage.raycastTarget = true;
    }
}
