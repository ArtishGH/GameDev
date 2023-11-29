using UnityEngine;

public class RayCast : MonoBehaviour
{
    [Header("Raycast Settings")]
    public float range = 10f;

    // Update is called once per frame
    void Update()
    {
        // Check if the transform is not null before using it
        if (transform != null)
        {
            // Direction of the raycast
            Vector3 direction = transform.forward;

            // Create a raycast
            Ray ray = new Ray(transform.position, direction * range);

            // Draw the raycast for debugging purposes
            Debug.DrawRay(transform.position, direction * range, Color.red);
        }
        else
        {
            Debug.LogError("Transform is null. Make sure this script is attached to a GameObject.");
        }
    }
}

