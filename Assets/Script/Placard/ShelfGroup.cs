using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShelfGroup : MonoBehaviour
{
    [SerializeField] private GameObject shelfPrefab; // Pr�fabriqu� pour Shelf
    [SerializeField] private GameObject shelfButtonPrefab; // Pr�fabriqu� pour ShelfButton
    [SerializeField] private Transform shelvesParent; // Parent pour les shelves
    [SerializeField] private Transform buttonsParent; // Parent pour les boutons
    [SerializeField] private HandManager handManager;
    [SerializeField] private TextMeshProUGUI descriptionText; // Référence à l'UI de description

    private List<Shelf> shelves = new List<Shelf>();
    private List<ShelfButton> shelfButtons = new List<ShelfButton>();

    public void SetupShelves(Furniture furniture)
    {
        ClearShelves();

        if (furniture.shelfContents == null || furniture.shelfContents.Count == 0)
        {
            Debug.LogWarning("Aucune �tag�re dans les donn�es du meuble.");
            return;
        }

        for (int i = 0; i < furniture.shelfContents.Count; i++)
        {
            GameObject buttonObj = Instantiate(shelfButtonPrefab, buttonsParent);
            ShelfButton shelfButton = buttonObj.GetComponent<ShelfButton>();
            shelfButton.shelfIndex = i;
            shelfButton.SetupButton(this, i, handManager, furniture);

            GameObject shelfObj = Instantiate(shelfPrefab, shelvesParent);
            Shelf shelf = shelfObj.GetComponent<Shelf>();

            shelf.SetHandItems(furniture.shelfContents[i].objects, descriptionText, handManager, i, furniture);

            shelves.Add(shelf);
            shelfButtons.Add(shelfButton);
        }
        
        ShowShelf(0);
    }

    public void ShowShelf(int index)
    {
        for (int i = 0; i < shelves.Count; i++)
        {
            if (i == index)
            {
                shelves[i].SetActive(true);
            }
            else
            {
                shelves[i].SetActive(false);
            }
        }
    }

    public void SetShelfButtonAction(int index)
    {
        if (index >= 0 && index < shelfButtons.Count)
        {
            shelfButtons[index].OnClick();
        }
    }

    private void ClearShelves()
    {
        foreach (ShelfButton button in shelfButtons)
        {
            if (button != null)
            {
                Destroy(button.gameObject);
            }
        }
        shelfButtons.Clear();
        
        foreach (Shelf shelf in shelves)
        {
            if (shelf != null)
            {
                Destroy(shelf.gameObject);
            }
        }
        shelves.Clear();
    }
}