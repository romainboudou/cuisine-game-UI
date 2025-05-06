using UnityEngine;

public class ObjectStove : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float maxDistance = 5f;
    [SerializeField] private LayerMask layer;

    private Stove currentStove; // Référence au dernier four touché

    void Update()
    {
        HandleStoveCanvas();
    }

    private void HandleStoveCanvas()
    {
        Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, maxDistance, layer))
        {
            // Vérifiez si l'objet touché a un script Stove attaché
            //Stove hitStove = hit.transform.GetComponent<Stove>();
            //Debug.Log(hit);

            /*if (hitStove != null)
            {
                // Si un nouvel objet Stove est détecté, on gère l'activation
                if (currentStove != hitStove)
                {
                    DisableCurrentStove(); // Désactive l'ancien
                    currentStove = hitStove;
                    currentStove.SetCanvasVisibility(true); // Active le nouveau Canvas
                }
            }*/
        }
        else
        {
            // Si aucun Stove n'est touché, désactive le Canvas actif
            DisableCurrentStove();
        }
    }

    private void DisableCurrentStove()
    {
        if (currentStove != null)
        {
            currentStove.SetCanvasVisibility(false); // Désactive le Canvas de l'ancien Stove
            currentStove = null; // Réinitialise la référence
        }
    }
}