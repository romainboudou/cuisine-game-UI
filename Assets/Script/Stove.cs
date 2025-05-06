using UnityEngine;
using UnityEngine.UI;

public class Stove : MonoBehaviour
{
    [Header("UI Components")]
    [SerializeField] private Canvas stoveCanvas;
    [SerializeField] private Slider temperatureSlider;
    [SerializeField] private Text temperatureText;

    [Header("Raycast Settings")]
    [SerializeField] private float maxDistance = 5f; // Distance maximale du raycast
    [SerializeField] private LayerMask layer; // Layer que le raycast doit toucher

    private float currentTemperature = 0f;

    void Start()
    {
        // Ajouter un listener au slider
        temperatureSlider.onValueChanged.AddListener(UpdateTemperature);
        stoveCanvas.enabled = false; // Le canvas est caché au début
    }

    void Update()
    {
        HandleRaycast(); // Gère le Raycast pour afficher/masquer le Canvas
    }

    private void HandleRaycast()
    {
        // Créer un Ray à partir de la position du four, dirigé vers l'avant du four
        Ray ray = new Ray(transform.position, transform.forward); 
        
        RaycastHit hit;
        
        if (Physics.Raycast(ray, out hit, maxDistance, layer))
        {
            Debug.Log(hit);
            SetCanvasVisibility(true);
        }
        else
        {
            // Si le raycast ne touche rien, on cache le slider
            SetCanvasVisibility(false);
        }
    }

    private void UpdateTemperature(float value)
    {
        // Mettre à jour la température
        currentTemperature = value;

        // Mettre à jour le texte
        if (temperatureText != null)
        {
            temperatureText.text = $"Température : {currentTemperature}°C";
        }
    }

    public float GetCurrentTemperature()
    {
        return currentTemperature;
    }

    public void SetCanvasVisibility(bool isVisible)
    {
        stoveCanvas.enabled = isVisible;
    }
}
