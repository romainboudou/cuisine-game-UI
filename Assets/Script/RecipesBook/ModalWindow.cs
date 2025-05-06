using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ModalWindow : MonoBehaviour
{
    public GameObject modalPanel;
    public TextMeshProUGUI titleText;
    public TextMeshProUGUI ingredientsText;
    public TextMeshProUGUI descriptionText;
    public FreezeGame freezeGameScript;

    public void OpenModal(Recipe recipe)
    {
        titleText.text = recipe.title;
        ingredientsText.text = string.Join("\n", recipe.ingredients);
        descriptionText.text = recipe.description;
        modalPanel.SetActive(true);

        freezeGameScript.Freeze();
    }

    public void CloseModal()
    {
        modalPanel.SetActive(false);

        freezeGameScript.Unfreeze();
    }
}
