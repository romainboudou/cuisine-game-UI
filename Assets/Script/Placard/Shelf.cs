
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Shelf : MonoBehaviour
{
    [SerializeField] List<KitchenObject> handItems;
    [SerializeField] GameObject itemDisplayPrefab;

    private List<GameObject> displayedItems = new List<GameObject>();
    private HandManager handManager;
    private int shelfIndex;
    private Furniture furniture;

    public void SetHandItems(List<KitchenObject> _handItems, TextMeshProUGUI descriptionText, HandManager manager, int index, Furniture _furniture)
    {
        handItems = _handItems;
        handManager = manager;
        shelfIndex = index;
        furniture = _furniture;
        DisplayItems(descriptionText);
    }

    private void DisplayItems(TextMeshProUGUI descriptionText)
    {
        ClearDisplayedItems();

        foreach (KitchenObject item in handItems)
        {
            GameObject newItem = Instantiate(itemDisplayPrefab, this.transform);

            // Associer le KitchenObject et le TextMeshProUGUI au bouton
            ObjectButton objectButton = newItem.GetComponent<ObjectButton>();
            if (objectButton != null)
            {
                objectButton.Initialize(item, descriptionText, handManager, shelfIndex, furniture);
            }

            // Définir l'image de l'objet
            newItem.GetComponent<Image>().sprite = item.image;
            displayedItems.Add(newItem);
        }
    }
    private void ClearDisplayedItems()
    {
        foreach (GameObject displayedItem in displayedItems)
        {
            Destroy(displayedItem);
        }
        displayedItems.Clear();
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    public void RemoveItem(KitchenObject item)
    {
        if (handItems.Contains(item))
        {
            handItems.Remove(item); 
        }
    }

    

}