
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Mousemovement : MonoBehaviour
{
    public float mouseSensivity = 200f;

    float xRotation = 0f;
    float yRotation = 0f;

    public float topClamp = -60f;
    public float bottomClamp = 60f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensivity * Time.deltaTime;

        xRotation -= mouseY;

        xRotation = Math.Clamp(xRotation, topClamp, bottomClamp);

        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(xRotation, yRotation, 0f);

    }
}

