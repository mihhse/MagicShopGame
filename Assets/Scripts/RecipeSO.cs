using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class RecipeSO : ScriptableObject
{
    public string recipeName;
    public int numberOfIngredients;
    public GameObject[] Ingredients;
    public GameObject[] OptionalIngredients;
    public GameObject itemToCraft;
}
