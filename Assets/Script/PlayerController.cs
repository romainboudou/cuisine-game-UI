using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Vitesse de déplacement
    public float turnSpeed = 100f; // Vitesse de rotation

    // Update is called once per frame
    void Update()
    {
        // Déplacement avant (Z) et arrière (S)
        float moveDirection = 0f;
        if (Input.GetKey(KeyCode.W)) // Avancer
        {
            moveDirection = 1f;
        }
        if (Input.GetKey(KeyCode.S)) // Reculer
        {
            moveDirection = -1f;
        }

        // Déplacement horizontal (avant/arrière) basé sur l'axe Z du personnage
        transform.Translate(Vector3.forward * moveDirection * moveSpeed * Time.deltaTime);

        // Rotation gauche (Q) et droite (D)
        float turnDirection = 0f;
        if (Input.GetKey(KeyCode.A)) // Tourner à gauche
        {
            turnDirection = -1f;
        }
        if (Input.GetKey(KeyCode.D)) // Tourner à droite
        {
            turnDirection = 1f;
        }

        // Rotation autour de l'axe Y (vertical)
        transform.Rotate(Vector3.up * turnDirection * turnSpeed * Time.deltaTime);
    }
}
