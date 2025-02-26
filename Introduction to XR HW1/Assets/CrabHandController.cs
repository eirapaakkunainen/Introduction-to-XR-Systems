using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

public class CrabHandController : MonoBehaviour
{
    private Animator animator;
    private bool isSciccorsTriggered = false;
    public InputActionReference action;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("isSciccorsTriggered", isSciccorsTriggered);

        action.action.Enable();

        action.action.performed += (ctx) =>
        {
            isSciccorsTriggered = !isSciccorsTriggered;
            animator.SetBool("isSciccorsTriggered", isSciccorsTriggered);
        };

    }

    private void onDisable()
    {
        action.action.Disable();
    }

}
