using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    public CharacterController controller; 
    public float movementSpeed = 5.0f; 
    public float gravity = -9.81f;
    Vector3 velocity;

    public float jumpForce = 5f;       // Kekuatan lompatan
    public bool isGrounded = false;    // Status apakah pemain berada di tanah atau tidak
    public LayerMask groundLayer;      // Layer untuk tanah

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    { 
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical"); 

        Vector3 move = transform.right * horizontal + transform.forward * vertical; 
        velocity.y += gravity * Time.deltaTime; 

        controller.Move(move * movementSpeed * Time.deltaTime); 

        controller.Move(velocity * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        isGrounded = false;  // Mengatur status pemain agar tidak bisa lompat lagi sampai menyentuh tanah
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Mengecek apakah pemain menyentuh tanah
        if (collision.gameObject.layer == LayerMask.NameToLayer("Ground"))
        {
            isGrounded = true;
        }
    }
}
