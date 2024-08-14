using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    [SerializeField] private GameObject ingredientPanel, ingredientSlot;
    [SerializeField] private TextMeshProUGUI recipeNameText;
    [SerializeField] private RecipeSO recipeSO;

    public void RecieveCraftingRecipe(RecipeSO recipeSO)
    {
        this.recipeSO = recipeSO;
        UpdateCraftingRecipe();
    }

    public void UpdateCraftingRecipe()
    {
        recipeNameText.text = recipeSO.recipeName;
        for (int i = 0; i < recipeSO.Ingredients.Length; i++)
        {
            GameObject newIngredientSlot = Instantiate(ingredientSlot);
            newIngredientSlot.transform.SetParent(ingredientPanel.transform);
            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientString = recipeSO.Ingredients[i].gameObject.GetComponent<Item>().ingredientTypeString;

            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().sprite = recipeSO.Ingredients[i].gameObject.GetComponent<Item>().itemSprite;
            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }
        if (recipeSO.OptionalIngredients != null)
        {
            GameObject newIngredientSlot = Instantiate(ingredientSlot);
            newIngredientSlot.transform.SetParent(ingredientPanel.transform);
            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientString = recipeSO.optionalIngredientType;

            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().sprite = recipeSO.OptionalIngredients[Random.Range(0, recipeSO.OptionalIngredients.Length)].gameObject.GetComponent<Item>().itemSprite;
            newIngredientSlot.GetComponent<CraftingItemSlot>().expectedIngredientImage.GetComponent<Image>().color = new Color32(255, 255, 255, 100);
        }

    }

    private void Update()
    {
        //to do if newingredient slot has more than 1 child set its expected ingredient image inactive
    }
}
