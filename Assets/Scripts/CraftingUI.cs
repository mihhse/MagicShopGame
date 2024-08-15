using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    [SerializeField] private GameObject ingredientPanel, ingredientSlot, recipeSlot;
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private RecipeSO recipeSO;
    [SerializeField] private GameObject craftingTable;
    [SerializeField] private List<GameObject> newIngredientsList = new List<GameObject>();
    [SerializeField] private List<bool> itemsMatching = new List<bool>();

    public void RecieveCraftingRecipe(RecipeSO recipeSO)
    {
        this.recipeSO = recipeSO;
        UpdateCraftingRecipe();
    }

    public void UpdateCraftingRecipe()
    {
        recipeNameText.text = recipeSO.recipeName;
        UpdateExpectedIngredientPanel();
        craftingTable.GetComponent<CraftingTable>().ReciveItemToCraft(recipeSO);
    }

    private void Update()
    {
        if (transform.GetChild(0).gameObject.CompareTag("Expected Ingredient Image"))
            ingredientPanel.SetActive(false);
        else ingredientPanel.SetActive(true);

            if (Input.GetButtonDown("Cancel"))
            craftingTable.GetComponent<CraftingTable>().CloseCraftingUI();
    }

    void UpdateExpectedIngredientPanel()
    {
        ClearIngredientPanel();

        for (int i = 0; i < recipeSO.Ingredients.Length; i++)
        {
            GameObject newIngredientSlot = Instantiate(ingredientSlot);
            newIngredientSlot.transform.SetParent(ingredientPanel.transform);
            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientString = recipeSO.Ingredients[i].gameObject.GetComponent<Item>().ingredientTypeString;

            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().sprite = recipeSO.Ingredients[i].gameObject.GetComponent<Item>().ingredientTypeSprite;


            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().color = new Color32(255, 255, 255, 100);

            newIngredientsList.Add(newIngredientSlot);
            itemsMatching.Add(new bool());
        }

        if (recipeSO.OptionalIngredients.Length > 0)
        {
            for (int i = 0; i < recipeSO.OptionalIngredients.Length; i++)
            {
                GameObject newIngredientSlot = Instantiate(ingredientSlot);
                newIngredientSlot.transform.SetParent(ingredientPanel.transform);
                newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientString = recipeSO.OptionalIngredients[i].gameObject.GetComponent<Item>().ingredientTypeString;

                newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().sprite = recipeSO.OptionalIngredients[i].gameObject.GetComponent<Item>().ingredientTypeSprite;
                newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().color = new Color32(255, 255, 255, 100);

                newIngredientsList.Add(newIngredientSlot);
                itemsMatching.Add(new bool());
            }
        }
    }

    public void ClearIngredientPanel()
    {
        for (int i = 0; i < ingredientPanel.transform.childCount; i++) // destroys all previous expected ingredients
        {
            Destroy(ingredientPanel.transform.GetChild(i).gameObject);
        }
    }

    public void CheckIfIngredientIsCorrect()
    {
        for (int i = 0; i < newIngredientsList.Count; i++)
        {
            if (newIngredientsList[i].gameObject.GetComponent<CraftingItemSlot>().expectedIngredientString == newIngredientsList[i].gameObject.transform.GetChild(0).GetComponent<Item>().ingredientTypeString)
            {
                itemsMatching[i] = true;
                Debug.Log("item" + i + " is matching");
            }
        }
    }

}
