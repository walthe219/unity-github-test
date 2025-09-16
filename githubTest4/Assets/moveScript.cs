using UnityEngine;

public class MoveScript : MonoBehaviour
{
    private CharacterController controller;
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = 20f; // Adjust for desired gravity

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Ground Movement
        float horizontalInput = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float verticalInput = Input.GetAxis("Vertical");   // W/S or Up/Down arrows

        // Calculate desired movement in XZ plane
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        Vector3 targetMove = (forward * verticalInput + right * horizontalInput).normalized * moveSpeed;

        // Apply gravity and jumping
        if (controller.isGrounded)
        {
            moveDirection.y = 0; // Reset vertical velocity when grounded
            if (Input.GetButtonDown("Jump")) // Spacebar by default
            {
                moveDirection.y = jumpForce;
            }
        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime; // Apply gravity
        }

        // Combine horizontal movement and vertical movement
        moveDirection.x = targetMove.x;
        moveDirection.z = targetMove.z;

        // Move the character
        controller.Move(moveDirection * Time.deltaTime);
    }
}
