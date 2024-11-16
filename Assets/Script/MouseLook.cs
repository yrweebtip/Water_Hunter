using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    private float xRotation = 0f;

    void Start()
    {
        // Kunci kursor di tengah layar dan sembunyikan
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Mengambil input mouse
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        // Mengatur rotasi pada sumbu X (vertikal) untuk memiringkan pandangan ke atas dan ke bawah
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Batasi rotasi vertikal agar tidak terlalu jauh

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX); // Rotasi pada sumbu Y (horizontal) untuk memutar karakter
    }
    void OnDrawGizmos()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Gizmos.color = Color.red;
            Gizmos.DrawLine(ray.origin, hit.point);
            
        }
    }
}



