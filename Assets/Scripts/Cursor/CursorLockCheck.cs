using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorLockCheck : MonoBehaviour
{
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

}