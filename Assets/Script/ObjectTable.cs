
using UnityEngine;

public class ObjectTable : MonoBehaviour
{
    [Header("Highlight Settings")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private LayerMask interactableLayer;
    [SerializeField] private Material highlightMaterial;

    [Header("Interaction Settings")]
    [SerializeField] private GameObject contextMenuPrefab;
    [SerializeField] private float menuHeightOffset = 2f;

    [Header("Hand Manager")]
    [SerializeField] private HandManager handManager; // R�f�rence au HandManager

    private Transform lastHighlightedObject;
    private GameObject currentMenu;
    private Material originalMaterial;
    public Vector3 clickPosition;
    

    void Update()
    {
        HandleHighlight();
        HandleInteraction();
    }

    private void HandleHighlight()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, interactableLayer))
        {
            Transform hitTransform = hit.transform;

            clickPosition = hit.point;

            if (lastHighlightedObject != hitTransform)
            {
                if (handManager.rightHand != null || handManager.leftHand != null)
                {
                    ClearHighlight();
                    HighlightObject(hitTransform);
                }
            }
        }
        else
        {
            ClearHighlight();
        }
    }

    private void HighlightObject(Transform obj)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            originalMaterial = renderer.material;
            renderer.material = highlightMaterial;
            lastHighlightedObject = obj;
        }
    }

    private void ClearHighlight()
    {
        if (lastHighlightedObject != null)
        {
            Renderer renderer = lastHighlightedObject.GetComponent<Renderer>();
            if (renderer != null && originalMaterial != null)
            {
                renderer.material = originalMaterial;
            }
            lastHighlightedObject = null;
        }
    }

    private void HandleInteraction()
    {
        if (Input.GetMouseButtonDown(0) && lastHighlightedObject != null)
        {
            ShowContextMenu(lastHighlightedObject);
        }
        if (Input.GetMouseButtonDown(1))
        {
            if(currentMenu != null)
            {
                Destroy(currentMenu);
            }
        }
    }

    private void ShowContextMenu(Transform target)
    {
        if (currentMenu != null)
        {
            Destroy(currentMenu);
        }

        Vector3 menuPosition = target.position + Vector3.up * menuHeightOffset;
        currentMenu = Instantiate(contextMenuPrefab, menuPosition, Quaternion.identity);
        currentMenu.transform.LookAt(playerCamera.transform);
        currentMenu.transform.Rotate(0, 180, 0);

        // Configure le menu contextuel
        MenuController menuController = currentMenu.GetComponent<MenuController>();
        if (menuController != null)
        {
            menuController.Setup(target.gameObject, handManager);
        }
    }

}
