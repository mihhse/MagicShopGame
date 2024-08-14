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
    [HideInInspector] public Image DDimage;

    [SerializeField] private string itemName;
    [SerializeField] private Sprite itemSprite;
    [SerializeField] public string ingredientTypeString;
    public RecipeSO recipeSO;


    public GameObject originalItemSlot;


    [HideInInspector] public Transform parentAfterDrag;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup= GetComponent<CanvasGroup>();
        GameObject tempcanvas = GameObject.Find("Canvas");
        canvas = tempcanvas.GetComponent<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //visuals
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;

        //get information from original item slot
        originalItemSlot = eventData.pointerDrag.gameObject; // original item is set to game object of the item slot below
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();

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

    public void ReceiveItemData(string itemName, Sprite itemSprite, string ingredientTypeString, RecipeSO recipeSO)
    {
        this.itemName = itemName;
        this.itemSprite = itemSprite;
        this.DDimage.sprite = itemSprite;
        this.gameObject.SetActive(true);
        this.ingredientTypeString = ingredientTypeString;
        this.recipeSO = recipeSO;
        Debug.Log(this.itemName);
    }
}
