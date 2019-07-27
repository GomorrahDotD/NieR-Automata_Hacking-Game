using System.Collections;
using UnityEngine;

public class mbPlayerController : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 2f;

    private CharacterController character;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        transform.position = new Vector3(0f, 0.5f, -3.48f);
    }

    private void Update()
    {
        // Get Inputs (made accessible for debugging)
        // GetAxis("Rotation") is a new Input I created in the project Settings
        float hAxis = Input.GetAxis("Horizontal");
        float vAxis = Input.GetAxis("Vertical");
        float rAxis = Input.GetAxis("Rotation");

        // Moves the Player in 3D Space (independend from its rotation)
        Vector3 movement = new Vector3(hAxis, 0, vAxis) * speed * Time.deltaTime;
        character.Move(movement);

        // Rotates the Player around its y-axis
        Vector3 rotation = new Vector3(0f, rAxis, 0f) * rotationSpeed * Time.deltaTime;
        transform.Rotate(rotation);
    }
}

