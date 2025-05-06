using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public List<Recipe> recipes = new List<Recipe>();

    public void AddRecipe(Recipe recipe)
    {
        recipes.Add(recipe);
    }

    public Recipe GetRecipe(int index)
    {
        if (index >= 0 && index < recipes.Count)
        {
            return recipes[index];
        }
        return null;
    }
}
