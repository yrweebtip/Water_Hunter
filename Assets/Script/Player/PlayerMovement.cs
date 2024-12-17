using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float movementSpeed = 5.0f;
    public float sprintSpeed = 8.0f; 
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;
    public float jumpHeight = 3.0f;

    private Vector3 velocity;
    private bool isGrounded;

    public Transform playerCamera; 
    public float crouchHeight = 1f; 
    public float standHeight = 2f; 
    public float crouchSpeed = 2f; 
    public float normalSpeed = 5f;

    private float currentSpeed;
    private bool isCrouching = false;

    void Start()
    {
        if (characterController == null)
        {
            characterController = GetComponent<CharacterController>();
        }

        currentSpeed = normalSpeed;
    }

    void Update()
    {
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; 
        }

        HandleMovement();
        HandleCrouch();
        HandleSprint(); 

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

       
        velocity.y += gravity * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);
    }

    void HandleMovement()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 move = transform.right * horizontal + transform.forward * vertical;
        characterController.Move(move * currentSpeed * Time.deltaTime);
    }

    void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl)) 
        {
            ToggleCrouch();
        }
    }

    void HandleSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching) 
        {
            currentSpeed = sprintSpeed;
        }
        else if (!isCrouching)
        {
            currentSpeed = normalSpeed;
        }
    }

    void ToggleCrouch()
    {
        isCrouching = !isCrouching;

        if (isCrouching)
        {
           
            characterController.height = crouchHeight;
            playerCamera.localPosition = new Vector3(0, crouchHeight / 2, 0);
            currentSpeed = crouchSpeed;
        }
        else
        {
            
            characterController.height = standHeight;
            playerCamera.localPosition = new Vector3(0, standHeight / 2, 0);
            currentSpeed = normalSpeed;
        }
    }
}