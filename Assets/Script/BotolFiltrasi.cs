using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BotolFiltrasi : MonoBehaviour
{
    private List<string> urutanBenar = new List<string> { "Kerikil", "Arang", "Spons", "Ijuk" };
    private List<string> urutanPemain = new List<string>();

    public GameObject objekAir;

    public void TambahLapisan(string namaLapisan)
    {
        if (urutanPemain.Count < urutanBenar.Count)
        {
            urutanPemain.Add(namaLapisan);
        }
    }

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objekAir)
        {
            if (UrutanBenar())
            {
                Debug.Log("Kondisi Menang: Lapisan benar! Air bisa disaring.");
                // Tambahkan logika kondisi menang, seperti lanjut level atau tampilan pesan sukses.
            }
            else
            {
                Debug.Log("Kondisi Gagal: Urutan salah. Air tidak bisa disaring.");
                // Tambahkan logika kondisi gagal, seperti efek visual atau suara kesalahan.
            }
        }
    }
}

