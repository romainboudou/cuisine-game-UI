using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlacardWindow : MonoBehaviour
{
    public GameObject placardPanel;
    public FreezeGame freezeGameScript;
    public Furniture furniture;

    public void OpenModal()
    {
        placardPanel.SetActive(true);
        freezeGameScript.Freeze();
    }

    public void CloseModal()
    {
        placardPanel.SetActive(false);

        freezeGameScript.Unfreeze();
    }
}
