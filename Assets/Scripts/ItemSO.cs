using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ItemSO : ScriptableObject
{
    public string itemName;
    public IngredientType ingredientType = new IngredientType();



    public enum IngredientType
    {
        None,
        Wood,
        Metal,
        Crystal,
        Recipe
    };
}
