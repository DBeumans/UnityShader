﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour {

    private static Vector3 movementInput;
    public static Vector3 Get_MovementInput { get { return movementInput; } }

    private static float scrollWheel;
    public static float Get_ScrollWheel { get { return scrollWheel; } }

    private static float mouseX;
    public static float Get_MouseX { get { return mouseX; } }

    private static float mouseY;
    public static float Get_MouseY { get { return mouseY; } }

    private static bool key_shift;
    public static bool Get_Key_Shift { get { return key_shift; } }

    private KeyCode keycode_shift = KeyCode.LeftShift;

    private void Update()
    {
        movementInput = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);

        scrollWheel = Input.GetAxis("Mouse ScrollWheel");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");

        key_shift = Input.GetKey(keycode_shift);
        

        if (Input.GetKeyDown(KeyCode.Space))
            Cursor.lockState = CursorLockMode.Locked;


    }
}
