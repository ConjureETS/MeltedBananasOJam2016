﻿using UnityEngine;
using System.Collections;

public class ViewControl : MonoBehaviour
{

    // Speed at which the camera will catch up to the mouse pointer location
    public float mouseSensitivity = 100.0f;
    public float clampAngle = 80.0f;

    private float rotY = 0.0f;
    // rotation around the up/y axis
    private float rotX = 0.0f;
    // rotation around the right/x axis

    // Use this for initialization
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        Vector3 rot = transform.localRotation.eulerAngles;
        rotY = rot.y;
        rotX = rot.x;
    }

    // Called once every physics update
    void FixedUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");
 
        rotY += mouseX * mouseSensitivity * Time.deltaTime;
        rotX += mouseY * mouseSensitivity * Time.deltaTime;
 
        rotX = Mathf.Clamp(rotX, -clampAngle, clampAngle);
 
        Quaternion localRotation = Quaternion.Euler(rotX, rotY, 0.0f);
        transform.rotation = localRotation;
    }
}
