using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleFiltrasiAir : MonoBehaviour

{
    // Daftar untuk menyimpan urutan lapisan yang benar
    private List<string> urutanBenar = new List<string> { "Kerikil", "Arang", "Spons", "Ijuk" };

    // Daftar untuk melacak urutan lapisan pemain
    private List<string> urutanPemain = new List<string>();

    // Referensi ke objek air
    public GameObject objekAir;

    // Memeriksa apakah pemain mengatur lapisan dengan benar
    public bool UrutanBenar()
    {
        if (urutanPemain.Count != urutanBenar.Count) return false;

        for (int i = 0; i < urutanBenar.Count; i++)
        {
            if (urutanPemain[i] != urutanBenar[i])
            {
                return false;
            }
        }
        return true;
    }

    // Fungsi untuk menambahkan lapisan ke urutan pemain
    public void TambahLapisan(string namaLapisan)
    {
        if (urutanPemain.Count < urutanBenar.Count)
        {
            urutanPemain.Add(namaLapisan);
        }
    }

    // Fungsi untuk mereset urutan pemain
    public void ResetLapisan()
    {
        urutanPemain.Clear();
    }

    // Memeriksa interaksi dengan objek air
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objekAir)
        {
            if (UrutanBenar())
            {
                Debug.Log("Kondisi Menang Tercapai! Air mengalir melalui filter.");
                // Menjalankan kondisi menang, misalnya, lanjut ke level berikutnya atau tampilkan pesan sukses
            }
            else
            {
                Debug.Log("Urutan salah. Air tidak bisa mengalir.");
                // Opsional: berikan umpan balik kepada pemain, seperti suara atau efek visual
            }
        }
    }
}

