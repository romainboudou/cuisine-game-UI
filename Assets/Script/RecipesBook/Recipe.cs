using UnityEngine;

[CreateAssetMenu(fileName = "NewRecipe", menuName = "Recipe")]
public class Recipe : ScriptableObject
{
    public string title;
    public string[] ingredients;
    public string description;

    public string GetFormattedRecipe()
    {
        string formattedIngredients = string.Join("\n", ingredients);
        return $"<color=#434343><b>{title}</b></color>\n\n" +
               $"<color=#434343><b>Ingredients:</b></color>\n" +
               $"<color=#434343>{formattedIngredients}</color>\n\n" +
               $"<color=#434343><b>Description:</b></color>\n" +
               $"<color=#434343>{description}</color>";
    }

}
