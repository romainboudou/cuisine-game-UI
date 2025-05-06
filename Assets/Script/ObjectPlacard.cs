using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ObjectPlacard : MonoBehaviour
{
    [Header("Highlight Settings")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private LayerMask placardLayer;
    [SerializeField] private Material highlightMaterial;
    public HandManager handManager;
    public PlacardWindow window;
    private Transform lastHighlightedObject;
    private Material originalMaterial;
    private Dictionary<Renderer, Material> originalMaterials = new Dictionary<Renderer, Material>();

    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) return;

        HandleHighlight(); // Reste responsable du survol (highlight)
        HandleInteraction(); // G�re le clic et l'ouverture du placard
    }

    private void HandleHighlight()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, placardLayer))
        {
            Transform hitTransform = hit.transform;

            if (lastHighlightedObject != hitTransform)
            {
                ClearHighlight();
                HighlightObject(hitTransform);
            }
        }
        else
        {
            ClearHighlight();
        }
    }

    private void HighlightObject(Transform obj)
    {
        if (obj == null) return;

        // Trouver tous les Renderer dans l'objet et ses enfants
        Renderer[] renderers = obj.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if (renderer != null)
            {
                // Sauvegarder le mat�riel original
                if (!originalMaterials.ContainsKey(renderer))
                {
                    originalMaterials[renderer] = renderer.material;
                }

                // Appliquer le mat�riel de surlignage
                renderer.material = highlightMaterial;
            }
        }

        lastHighlightedObject = obj;
    }

    private void ClearHighlight()
    {
        if (lastHighlightedObject == null) return;

        Renderer[] renderers = lastHighlightedObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            if (renderer != null && originalMaterials.ContainsKey(renderer))
            {
                renderer.material = originalMaterials[renderer];
            }
        }
        
        originalMaterials.Clear();
        lastHighlightedObject = null;
    }

    private void HandleInteraction()
    {
        if (Input.GetMouseButtonDown(0) && lastHighlightedObject != null)
        {
            Furniture hitFurniture = lastHighlightedObject.GetComponent<Furniture>();
            if (hitFurniture != null)
            {
                handManager.SetCurrentFurniture(hitFurniture);
                window.OpenModal();
                Debug.Log("Placard s�lectionn�, contient " + hitFurniture.shelfContents.Count + " �tag�res.");
                hitFurniture.InitializeShelves();
                ClearHighlight();
            }
        }
    }
}
