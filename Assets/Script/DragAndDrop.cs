using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;
    private Vector2 originalPosition;

    // Tambahkan referensi ke Canvas
    private Canvas canvas;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        originalPosition = rectTransform.anchoredPosition;

        // Mendapatkan referensi ke Canvas
        canvas = GetComponentInParent<Canvas>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 0.6f; // Membuat objek lebih transparan saat diseret
        canvasGroup.blocksRaycasts = false; // Mematikan raycast agar objek bisa dilepas
    }

    public void OnDrag(PointerEventData eventData)
    {
        // Memindahkan objek mengikuti gerakan mouse
        // Gunakan canvas.scaleFactor untuk memperhitungkan skala Canvas
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        // Kembalikan ke posisi awal jika tidak dilepas di area yang benar
        rectTransform.anchoredPosition = originalPosition;
    }
}