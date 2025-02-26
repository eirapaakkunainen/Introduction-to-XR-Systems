using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeDetector : MonoBehaviour
{
    public List<Rigidbody> ingredients = new List<Rigidbody>(); 
    public float shakeThreshold = 0.8f; 
    private Vector3 lastVelocity;
    private Rigidbody boxRb;

    void Start()
    {
        boxRb = GetComponent<Rigidbody>();

        foreach (Rigidbody ingredient in ingredients)
        {
            ingredient.isKinematic = true;
            ingredient.transform.parent = transform;
        }
    }

    void Update()
    {
        Vector3 acceleration = (boxRb.velocity - lastVelocity) / Time.deltaTime;
        lastVelocity = boxRb.velocity;

        
        if (acceleration.magnitude > shakeThreshold)
        {
            ReleaseIngredients();
        }
    }

    void ReleaseIngredients()
    {
        
        foreach (Rigidbody ingredient in ingredients)
        {
            ingredient.isKinematic = false;
            ingredient.transform.parent = null;
        }

    }
}

