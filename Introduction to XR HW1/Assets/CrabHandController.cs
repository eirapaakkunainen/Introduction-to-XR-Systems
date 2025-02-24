using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class CrabHandController : MonoBehaviour
{
    private Animator animator;
    private bool isClawOpen = false;
    public InputActionReference action;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("isClawOpen", isClawOpen);

        action.action.Enable();

        action.action.performed += (ctx) =>
        {
            isClawOpen = !isClawOpen;
            animator.SetBool("isClawOpen", isClawOpen);
        };

    }
}
