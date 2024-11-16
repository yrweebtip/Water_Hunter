using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float walkSpeed = 3f;
    public float crouchSpeed = 1.5f;
    public float jumpForce = 5f;
    public float crouchHeight = 0.5f;
    public float standHeight = 2f;
    public Transform playerCamera;
    public float rotationSpeed = 2f;
    private bool isCrouching = false;
    private CapsuleCollider playerCollider;
    private Vector3 originalCenter;

    private float currentSpeed;
    private Rigidbody rb;

    private bool isGrounded;  // Menambahkan variabel untuk memeriksa apakah karakter berada di tanah
    public float groundCheckDistance = 0.1f;  // Jarak untuk memeriksa tanah
    public LayerMask groundLayer;  // Layer tanah

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();
        originalCenter = playerCollider.center; // Menyimpan posisi center collider awal
        currentSpeed = walkSpeed; // Set default speed ke walkSpeed
    }

    void Update()
    {
        CheckGrounded();  // Memeriksa apakah pemain berada di tanah
        Move();
        Jump();
        Crouch();
        Rotate();
    }

    void Move()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 move = transform.right * moveX + transform.forward * moveZ;
        transform.Translate(move * currentSpeed * Time.deltaTime, Space.World);
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded) // Melompat hanya jika berada di tanah
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void Crouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) && !isCrouching)
        {
            // Jongkok
            isCrouching = true;
            currentSpeed = crouchSpeed; // Mengubah kecepatan saat jongkok
            playerCollider.height = crouchHeight; // Menurunkan tinggi collider
            playerCollider.center = new Vector3(0, crouchHeight / 2, 0); // Mengatur posisi center collider
            playerCamera.localPosition = new Vector3(0, crouchHeight / 2, 0); // Menurunkan kamera agar tidak terlalu tinggi
        }
        else if (Input.GetKeyDown(KeyCode.LeftControl) && isCrouching)
        {
            // Berdiri
            isCrouching = false;
            currentSpeed = walkSpeed; // Mengembalikan kecepatan normal
            playerCollider.height = standHeight; // Mengembalikan tinggi collider
            playerCollider.center = originalCenter; // Mengembalikan posisi center collider
            playerCamera.localPosition = new Vector3(0, standHeight / 2, 0); // Mengembalikan posisi kamera
        }
    }

    void Rotate()
    {
        float mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
        float mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;

        transform.Rotate(Vector3.up * mouseX); // Rotasi horizontal

        // Rotasi vertikal
        float rotationX = playerCamera.localEulerAngles.x - mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Mencegah rotasi melebihi batas
        playerCamera.localEulerAngles = new Vector3(rotationX, 0, 0);
    }

    // Fungsi untuk memeriksa apakah pemain berada di tanah
    void CheckGrounded()
    {
        // Menggunakan raycast untuk memeriksa apakah karakter berada di tanah
        isGrounded = Physics.Raycast(transform.position, Vector3.down, playerCollider.height / 2 + groundCheckDistance, groundLayer);
    }
}


