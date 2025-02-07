using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GrabLens : MonoBehaviour
{
    public InputActionReference grabLens;
    public Transform cubeAsHand;

    private GameObject magnifyingLens = null;
    private bool lensOnHand = false;
 
    void Start()
    {
        grabLens.action.Enable();
        grabLens.action.performed += (ctx) => GrabOrUngrab();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            magnifyingLens = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == magnifyingLens)
        {
            magnifyingLens = null;
        }
    }

    void GrabOrUngrab()
    {
        if (magnifyingLens == null)
        {
            return;
        }

        Rigidbody rigidbody = magnifyingLens.GetComponent<Rigidbody>();
        if (lensOnHand)
        {
            //lens is on the hand, ungrab the lens 
            magnifyingLens.transform.SetParent(null);
            rigidbody.isKinematic = false;
        }
        else
        {
            //grab lens
            magnifyingLens.transform.SetParent(cubeAsHand);
            magnifyingLens.transform.localPosition = Vector3.zero;
            magnifyingLens.transform.localRotation = Quaternion.identity;
            rigidbody.isKinematic = true;
        }

        lensOnHand = !lensOnHand;
    }
}
