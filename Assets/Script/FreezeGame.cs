using UnityEngine;

public class FreezeGame : MonoBehaviour
{
    private bool isGameFrozen = false;

    // M�thode pour geler le jeu
    public void Freeze()
    {
        Time.timeScale = 0f;       
        isGameFrozen = true;
    }

    // M�thode pour d�-geler le jeu
    public void Unfreeze()
    {
        Time.timeScale = 1f;
        isGameFrozen = false;
    }

    // Optionnel : Vous pouvez utiliser cette fonction pour v�rifier si le jeu est gel�.
    public bool IsGameFrozen()
    {
        return isGameFrozen;
    }
}
