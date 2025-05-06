using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class ObjectButton : MonoBehaviour, IPointerDownHandler
{
    [Header("Description Panel")]
    public TextMeshProUGUI descriptionText; 
    private KitchenObject kitchenObject;
    private Furniture furniture;
    private int shelfIndex;
    private HandManager handManager;

    public void Initialize(KitchenObject obj, TextMeshProUGUI _descriptionText, HandManager manager, int index, Furniture _furniture)
    {
        kitchenObject = obj;
        descriptionText = _descriptionText;
        handManager = manager;
        shelfIndex = index;
        furniture = _furniture;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (handManager != null)
        {
            handManager.SetSelectedKitchenObject(kitchenObject, furniture, shelfIndex); // Définir l'objet sélectionné
            descriptionText.text = kitchenObject.description;

        }
        else
        {
            Debug.LogError("HandManager n'est pas assigné !");
        }
    }
}
