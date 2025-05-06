using TMPro;
using UnityEngine;

public class RecipeCreator : MonoBehaviour
{
    public Book book;
    public TMP_InputField titleInput;
    public TMP_InputField ingredientsInput;
    public TMP_InputField descriptionInput;

    public void CreateRecipe()
    {
        Recipe newRecipe = ScriptableObject.CreateInstance<Recipe>();
        newRecipe.title = titleInput.text;
        newRecipe.ingredients = ingredientsInput.text.Split('\n');
        newRecipe.description = descriptionInput.text;

        book.AddRecipe(newRecipe);
    }
}
