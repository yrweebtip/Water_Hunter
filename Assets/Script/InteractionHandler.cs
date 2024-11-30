using UnityEngine;

public class InteractionHandler : MonoBehaviour
{
    public Transform holdPoint; // Titik tempat item dipegang
    public GameObject botolFiltrasi; // Referensi ke objek BotolFiltrasi
    public GameObject air; // Objek air yang akan diinteraksi
    public GameObject winPanel; // Panel kemenangan (atau metode untuk menampilkan kemenangan)

    private void Start()
    {
        if (winPanel != null)
            winPanel.SetActive(false); // Pastikan panel kemenangan tersembunyi di awal
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) // Tombol untuk berinteraksi
        {
            CheckInteraction();
        }
    }

    private void CheckInteraction()
    {
        if (IsHoldingBotolFiltrasi() && IsNearObject(air))
        {
            TriggerWinCondition();
        }
        else if (IsNearObject(air))
        {
            Debug.Log("Anda perlu memegang BotolFiltrasi untuk menyelesaikan permainan.");
        }
    }

    private bool IsHoldingBotolFiltrasi()
    {
        // Memeriksa apakah BotolFiltrasi berada di HoldPoint
        return botolFiltrasi.transform.parent == holdPoint;
    }

    private bool IsNearObject(GameObject targetObject)
    {
        // Cek apakah pemain berada dalam jarak dekat dengan objek tertentu
        float interactionDistance = 2.0f; // Sesuaikan jaraknya sesuai kebutuhan
        return Vector3.Distance(transform.position, targetObject.transform.position) <= interactionDistance;
    }

    private void TriggerWinCondition()
    {
        Debug.Log("Selamat! Anda berhasil menyelesaikan permainan.");
        if (winPanel != null)
            winPanel.SetActive(true); // Tampilkan panel kemenangan jika disediakan
        // Tambahkan logika lain untuk menang, seperti transisi scene
    }
}

