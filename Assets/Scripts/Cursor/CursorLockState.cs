using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockState : MonoBehaviour
{

    public static void ToggleCursorLockState()
    {
        if (GetCursorLockState() == CursorLockMode.Locked)
        {
            Cursor.lockState = CursorLockMode.None;
            return;
        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            return;
        }

    }

    public static CursorLockMode GetCursorLockState()
    {
        CursorLockMode mode;
        mode = Cursor.lockState;
        return mode;
    }
}