using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GrabLens : MonoBehaviour
{
    public Camera magnifyingGlassCamera;
    public InputActionReference grabLens;
    public Transform cubeAsHand;
    public RenderTexture zoomedRenderTexure;
    public RenderTexture normalRenderTexture;
    private GameObject magnifyingLens = null;
    private bool lensOnHand = false;
    private Material lensMaterial;
 
    void Start()
    {
        grabLens.action.Enable();
        grabLens.action.performed += (ctx) => GrabOrUngrab();

        if (magnifyingLens != null)
        {
            lensMaterial = magnifyingLens.GetComponent<Renderer>().material;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Grabbable"))
        {
            magnifyingLens = other.gameObject;
            lensMaterial = magnifyingLens.GetComponent<Renderer>().material;
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

            //when lens is ungrabbed, render texture normal
            if (lensMaterial != null)
            {
                lensMaterial.mainTexture = normalRenderTexture;
            }
        }
        else
        {
            //grab lens
            magnifyingLens.transform.SetParent(cubeAsHand);
            magnifyingLens.transform.localPosition = Vector3.zero;
            magnifyingLens.transform.localRotation = Quaternion.identity;
            rigidbody.isKinematic = true;

            //when lens is grabbed, zoom 
            if (lensMaterial != null)
            {
                lensMaterial.mainTexture = zoomedRenderTexure;
            }

        }

        lensOnHand = !lensOnHand;
    }
}
