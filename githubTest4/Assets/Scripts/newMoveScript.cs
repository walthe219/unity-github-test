using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class newMoveScript : MonoBehaviour
{
    private CharacterController controller;

    public float moveSpeed = 5f;
    public float jumpStr = 8f;
    public float gravity = 20f;

    InputAction move;
    InputAction jump;

    Vector3 xMove = Vector3.zero;
    Vector3 yMove = Vector3.zero;
    Vector3 zMove = Vector3.zero;
    float yVelocity = 0f;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
    }

    private void Update()
    {
        //Movement Calculations
        Vector2 moveValue = move.ReadValue<Vector2>();
        xMove = transform.right * moveValue.x * moveSpeed;
        zMove = transform.forward * moveValue.y * moveSpeed;


        //Jump Calculations
        if (controller.isGrounded)
        {
            yVelocity = 0f;
            if (jump.IsPressed())
            {
                yMove = transform.up * jumpStr;
            }
        }
        else
        {
            yVelocity -= gravity;
            yMove = transform.up * yVelocity;
        }

        

    }

    private void FixedUpdate()
    {
        controller.Move((xMove + yMove + zMove) * Time.fixedDeltaTime);
    }




















    /*
    private CharacterController controller;
    public float moveSpeed = 5f;
    public float jumpForce = 8f;
    public float gravity = 20f; // Adjust for desired gravity

    InputAction move;
    InputAction jump;

    Vector3 moveDirection;

    
    void Start()
    {
        move = InputSystem.actions.FindAction("Move");
        jump = InputSystem.actions.FindAction("Jump");
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        float prevY = moveDirection.y;
        moveDirection = Vector3.zero;
        Vector2 moveValue = move.ReadValue<Vector2>();
        

        if (moveValue != Vector2.zero)
        {
            moveDirection.x = moveValue.x * moveSpeed;
            moveDirection.z = moveValue.y * moveSpeed;
        }
        if (controller.isGrounded)
        {
            moveDirection.y = 0;
            if (jump.IsPressed())
            {
                moveDirection.y = jumpForce ;
            }
            
        }
        else
        {
            moveDirection.y = prevY - gravity;
        }

        
        
    }
    private void FixedUpdate()
    {
        controller.Move(moveDirection * Time.deltaTime);
    }
    */
}
