using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    [Header("Sensitivity Settings")]
    [SerializeField] private float mouseSensitivity = 100f;

    [Header("References")]
    [SerializeField] private Transform playerBody; // Le corps du joueur

    [Header("Input Actions")]
    [SerializeField] private InputActionReference lookActionRef;

    private float xRotation = 0f;

    private void OnEnable()
    {
        lookActionRef.action.Enable();
    }

    private void OnDisable()
    {
        lookActionRef.action.Disable();
    }


    private void Update()
    {
        RotateCamera();
    }

    private void RotateCamera()
    {
        // Lire les entrées de la souris
        Vector2 lookInput = lookActionRef.action.ReadValue<Vector2>();

        float mouseX = lookInput.x * mouseSensitivity * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensitivity * Time.deltaTime;

        // Rotation verticale (pitch)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Appliquer la rotation
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f); // Rotation verticale
        playerBody.Rotate(Vector3.up * mouseX); // Rotation horizontale
    }
}
