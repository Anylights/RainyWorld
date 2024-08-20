
using UnityEngine;

public class OnHitFunctionMovement : MonoBehaviour

{
    private Transform parentTransform; // Reference to the parent transform

    void Start()
    {
        parentTransform = transform.parent; // Get the parent transform
    }

    void Update()
    {
        if (parentTransform != null)
        {
            // Match the position of the child object to the position of the parent object
            transform.position = parentTransform.position;
        }
        else
        {
            Debug.LogWarning("Parent transform is missing!");
        }
    }
}