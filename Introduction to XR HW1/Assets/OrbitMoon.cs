using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMoon : MonoBehaviour
{
    public Transform planet;
    public float rotationSpeed = 20f;
    // Start is called before the first frame update
    void Update()
    {
        transform.RotateAround(planet.position, Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
