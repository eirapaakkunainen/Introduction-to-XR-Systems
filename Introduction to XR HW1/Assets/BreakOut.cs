using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class BreakOut : MonoBehaviour
{
    //creating the status is in the room with the value of true, because player starts from the room 
    private bool isInRoom = true;

    //possible locations
    public Transform insideTheRoom;
    public Transform OutsideView;

    public InputActionReference action;

    void Start()
    {
        action.action.Enable();

        action.action.performed += ChangeView;
    }

    void ChangeView(InputAction.CallbackContext callbackContenx)
    {
        if (isInRoom)
        {
            //change location to outside
            transform.position = OutsideView.position;
        }
        else
        {
            // change location back inside the room
            transform.position = insideTheRoom.position;
        }

        isInRoom = !isInRoom;
    }
        
        
}
