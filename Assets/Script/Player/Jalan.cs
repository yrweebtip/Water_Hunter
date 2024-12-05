using UnityEngine;

public class Jalan : MonoBehaviour
{
    public GameObject jalan;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jalan.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("w"))
        {
            berjalan();
        }

        if (Input.GetKeyDown("s"))
        {
            berjalan();
        }
        if(Input.GetKeyDown("a"))
        {
            berjalan();
        }
        if(Input.GetKeyDown("d"))
        {
            berjalan();
        }
        if(Input.GetKeyUp("w"))
        {
            tidakjalan();
        }
        if (Input.GetKeyUp("s"))
        {
            tidakjalan();
        }
        if (Input.GetKeyUp("a"))
        {
            tidakjalan();
        }
        if (Input.GetKeyUp("d"))
        {
            tidakjalan();
        }
    }
    void berjalan()
    { jalan.SetActive(true); }
    void tidakjalan()
    { jalan.SetActive(false); }
}
