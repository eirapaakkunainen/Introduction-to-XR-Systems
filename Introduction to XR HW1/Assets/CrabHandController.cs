using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class CrabHandController : MonoBehaviour
{
    private Animator animator;
    private bool isClawOpen = true;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        animator.SetBool("isClawOpen", isClawOpen);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            isClawOpen = !isClawOpen;
            animator.SetBool("isClawOpen", isClawOpen);
        }
    }
}
