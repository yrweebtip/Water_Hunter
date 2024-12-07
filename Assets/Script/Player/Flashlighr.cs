using UnityEngine;

public class Flashlighr : MonoBehaviour
{
    Light light;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.R))
        {
            light.enabled = !light.enabled;
        }
    }
}
