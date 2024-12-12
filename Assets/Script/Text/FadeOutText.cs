using UnityEngine;
using TMPro;
using System.Collections;

public class FadeOutText : MonoBehaviour
{
    public TextMeshProUGUI text; // Jika menggunakan TextMeshPro
    // public Text text; // Jika menggunakan UI Text biasa
    public float fadeDuration = 2f; // Waktu yang dibutuhkan untuk menghilang

    private void Start()
    {
        if (text == null)
        {
            text = GetComponent<TextMeshProUGUI>(); // Coba dapatkan komponen jika belum diset
        }
    }

    public void StartFadeOut()
    {
        StartCoroutine(FadeOut());
    }

    private IEnumerator FadeOut()
    {
        Color originalColor = text.color;
        float elapsedTime = 0f;

        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            float alpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            text.color = new Color(originalColor.r, originalColor.g, originalColor.b, alpha);
            yield return null;
        }

        text.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f); // Pastikan benar-benar transparan
    }
}

