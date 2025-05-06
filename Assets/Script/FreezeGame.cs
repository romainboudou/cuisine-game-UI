using UnityEngine;

public class FreezeGame : MonoBehaviour
{
    private bool isGameFrozen = false;

    // Méthode pour geler le jeu
    public void Freeze()
    {
        Time.timeScale = 0f;       
        isGameFrozen = true;
    }

    // Méthode pour dé-geler le jeu
    public void Unfreeze()
    {
        Time.timeScale = 1f;
        isGameFrozen = false;
    }

    // Optionnel : Vous pouvez utiliser cette fonction pour vérifier si le jeu est gelé.
    public bool IsGameFrozen()
    {
        return isGameFrozen;
    }
}
