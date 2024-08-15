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

    public void RecieveCraftingRecipe(RecipeSO recipeSO)
    {
        this.recipeSO = recipeSO;
        UpdateCraftingRecipe();
    }

    public void UpdateCraftingRecipe()
    {
        recipeNameText.text = recipeSO.recipeName;
        UpdateExpectedIngredientPanel();
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

            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().sprite = recipeSO.Ingredients[i].gameObject.GetComponent<Item>().itemSprite;
            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().color = new Color32(255, 255, 255, 100);

            newIngredientsList.Add(newIngredientSlot);

        }

        if (recipeSO.OptionalIngredients.Length > 0)
        {
            GameObject newIngredientSlot = Instantiate(ingredientSlot);
            newIngredientSlot.transform.SetParent(ingredientPanel.transform);
            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientString = recipeSO.optionalIngredientType;

            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().sprite = recipeSO.OptionalIngredients[Random.Range(0, recipeSO.OptionalIngredients.Length)].gameObject.GetComponent<Item>().itemSprite;
            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().color = new Color32(255, 255, 255, 100);

            newIngredientsList.Add(newIngredientSlot);
        }
    }

    public void ClearIngredientPanel()
    {
        for (int i = 0; i < ingredientPanel.transform.childCount; i++) // destroys all previous expected ingredients
        {
            Destroy(ingredientPanel.transform.GetChild(i).gameObject);
        }
    }

}
