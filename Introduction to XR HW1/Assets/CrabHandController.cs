using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CrabHandController : MonoBehaviour
{
    private Animator animator;
    private bool isClawOpen = false;

    private InputDevice leftController;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();

        leftController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
    }

    // Update is called once per frame
    void Update()
    {
        if (leftController.isValid)
        {
            isClawOpen = !isClawOpen;

            animator.SetBool("isClawOpen", isClawOpen);
        }
    }
}
