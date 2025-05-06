using TMPro;
using UnityEngine;

public class BookNavigation : MonoBehaviour
{
    public Book book;
    public TextMeshProUGUI recipeText;
    public ModalWindow modalWindow;
    private int currentIndex = 0;

    void Start()
    {
        DisplayRecipe();
    }

    public void NextPage()
    {
        currentIndex = (currentIndex + 1) % book.recipes.Count;
        DisplayRecipe();
    }

    public void PreviousPage()
    {
        currentIndex = (currentIndex - 1 + book.recipes.Count) % book.recipes.Count;
        DisplayRecipe();
    }

    void DisplayRecipe()
    {
        Recipe recipe = book.GetRecipe(currentIndex);
        if (recipe != null)
        {
            recipeText.text = recipe.GetFormattedRecipe();
        }
    }
    public void ShowRecipeDetails()
    {
        Recipe recipe = book.GetRecipe(currentIndex);
        if (recipe != null)
        {
            modalWindow.OpenModal(recipe);  
        }
    }

}
