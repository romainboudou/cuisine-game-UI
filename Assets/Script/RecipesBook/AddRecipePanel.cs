using UnityEngine;

public class AddRecipePanel : MonoBehaviour
{
    public GameObject addRecipePanel; // Le panel modal contenant les InputFields
    public FreezeGame freezeGameScript;

    // Ouvre le panel modal
    public void OpenAddRecipePanel()
    {
        if (addRecipePanel != null)
        {
            addRecipePanel.SetActive(true); // Active le panel modal
            freezeGameScript.Freeze();
        }
    }

    // Ferme le panel modal
    public void CloseAddRecipePanel()
    {
        if (addRecipePanel != null)
        {
            addRecipePanel.SetActive(false); // Désactive le panel modal
            freezeGameScript.Unfreeze();   
        }
    }
}
