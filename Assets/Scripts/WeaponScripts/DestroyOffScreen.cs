using UnityEngine;

public class DestroyOffScreen : MonoBehaviour
{
    private float xBoundary = 11f;
    private float zBoundary = 8f;
    void Update()
    {
        if (transform.position.x > xBoundary || transform.position.x < -xBoundary || transform.position.z > zBoundary || transform.position.z < -zBoundary)
        {
            Destroy(gameObject);
        }
    }
}
