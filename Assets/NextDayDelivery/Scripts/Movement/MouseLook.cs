﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity;

    [Space]
    public bool canLook = true;

    [Space]
    public Transform playerBody;

    float xRotation = 0f;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Start()
    {
        mouseSensitivity = InfoStorage.Instance.sensitivity;
        //Locks cursor to screen centre. 
        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = false;
    }

    public void FixedUpdate()
    {

        if (canLook == true)
        {
            //Allows the player to look around with the mouse.
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.fixedDeltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.fixedDeltaTime;

            xRotation -= mouseY;
            //Ensures that the player can only look up and down to a maximum of 90 degrees. 
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }

    public void OnSliderValueChanged(float value)
    {
        mouseSensitivity = value;
        InfoStorage.Instance.sensitivity = value;
    }


}
