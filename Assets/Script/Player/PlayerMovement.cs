using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController characterController;
    public float movementSpeed = 5.0f;
    public float sprintSpeed = 8.0f; // Kecepatan saat lari
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundLayer;
    public float jumpHeight = 3.0f;

    private Vector3 velocity;
    private bool isGrounded;

    public Transform playerCamera; // Referensi ke kamera
    public float crouchHeight = 1f; // Tinggi saat jongkok
    public float standHeight = 2f; // Tinggi normal
    public float crouchSpeed = 2f; // Kecepatan saat jongkok
    public float normalSpeed = 5f; // Kecepatan normal

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
        // Cek apakah player di tanah
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayer);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; // Reset kecepatan vertikal saat menyentuh tanah
        }

        HandleMovement();
        HandleCrouch();
        HandleSprint(); // Tambahkan fitur lari

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Terapkan gravitasi
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
        if (Input.GetKeyDown(KeyCode.LeftControl)) // Tombol untuk mulai jongkok
        {
            ToggleCrouch();
        }
    }

    void HandleSprint()
    {
        if (Input.GetKey(KeyCode.LeftShift) && !isCrouching) // Lari jika tombol Shift ditekan dan tidak jongkok
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
            // Kurangi tinggi karakter dan kamera
            characterController.height = crouchHeight;
            playerCamera.localPosition = new Vector3(0, crouchHeight / 2, 0);
            currentSpeed = crouchSpeed;
        }
        else
        {
            // Kembali ke tinggi normal
            characterController.height = standHeight;
            playerCamera.localPosition = new Vector3(0, standHeight / 2, 0);
            currentSpeed = normalSpeed;
        }
    }
}