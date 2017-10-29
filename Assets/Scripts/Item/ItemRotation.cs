using UnityEngine;
using System.Collections;

public class ItemRotation : MonoBehaviour {

    private float rotationSpeed = 10;

    private void FixedUpdate()
    {
        rotation();
    }

    private void rotation()
    {
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }

}
