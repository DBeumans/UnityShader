using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour {

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private float posX, posY, posZ;

    private Vector3 offset;

    private float horizontal;

    [SerializeField]
    private float rotationSpeed;

    private CameraZoom cameraZoom;

    private void Start()
    {
        cameraZoom = GetComponent<CameraZoom>();


    }

    private void Update()
    {
        horizontal = InputManager.Get_MouseX * rotationSpeed;
        target.transform.Rotate(0, horizontal, 0);

        float desiredAngle = target.transform.eulerAngles.y;
        var rotation = Quaternion.Euler(0,desiredAngle,0);
        this.transform.position = target.transform.position - (rotation * offset);

        this.transform.LookAt(target.transform);
        posZ = -cameraZoom.Get_Distance;

        offset = new Vector3(posX, posY, posZ);
        
    }
}
