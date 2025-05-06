using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ShelfButton : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ShelfGroup shelfGroup; // R�f�rence � ShelfGroup
    public int shelfIndex; // L'index de la shelf associ�e
    private HandManager handManager;
    private Furniture furniture;
    private Button button;

    public void SetupButton(ShelfGroup group, int index, HandManager manager, Furniture _furniture)
    {
        shelfGroup = group;
        shelfIndex = index;
        handManager = manager;
        furniture = _furniture;
    }

    private void Start()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(OnClick);
    }

    // Lorsque l'on clique sur un bouton
    public void OnClick()
    {
        Debug.Log(shelfIndex);
        if (shelfGroup != null)
        {
            shelfGroup.ShowShelf(shelfIndex); // Afficher l'�tag�re associ�e
            handManager.SetSelectedShelf(shelfIndex, furniture);
        }
        else
        {
            Debug.LogError("ShelfGroup est null ! Assurez-vous que la r�f�rence est assign�e.");
        }
    }

    // G�re l'�v�nement de clic (pour activer/d�sactiver les �tag�res)
    public void OnPointerDown(PointerEventData eventData)
    {
        OnClick();
    }
}
