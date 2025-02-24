using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeDetector : MonoBehaviour
{
    public List<Rigidbody> ingredients = new List<Rigidbody>(); // List of ingredients inside the box
    public float shakeThreshold = 0.8f; // Sensitivity to shaking
    private Vector3 lastVelocity;
    private Rigidbody boxRb;

    void Start()
    {
        boxRb = GetComponent<Rigidbody>();

        // Ensure all ingredients start as kinematic so they don't fall before shaking
        foreach (Rigidbody ingredient in ingredients)
        {
            ingredient.isKinematic = true;
        }
    }

    void Update()
    {
        // Calculate the acceleration by checking the difference in velocity
        Vector3 acceleration = (boxRb.velocity - lastVelocity) / Time.deltaTime;
        lastVelocity = boxRb.velocity;

        foreach ( Rigidbody ingredient in ingredients)
        {
            if (ingredient.isKinematic)
            {
                ingredient.velocity = boxRb.velocity;
            }
        }
        // If the acceleration magnitude is high, "shake" detected
        if (acceleration.magnitude > shakeThreshold)
        {
            ReleaseIngredients();
        }
    }

    void ReleaseIngredients()
    {
        // Release all ingredients by disabling "isKinematic"
        foreach (Rigidbody ingredient in ingredients)
        {
            ingredient.isKinematic = false; // Allow them to be affected by gravity
        }

        // Optionally, unparent them so they don't follow the box
        foreach (Rigidbody ingredient in ingredients)
        {
            ingredient.transform.parent = null;
        }
    }
}

