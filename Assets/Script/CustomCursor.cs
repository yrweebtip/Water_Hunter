using UnityEngine;

public class CustomCursor : MonoBehaviour
{
  private void Awake()
    {
        transform.position = Input.mousePosition;
    }

    private void Update()
    {
        transform.position = Input.mousePosition;
    }
}
