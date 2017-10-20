using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowObject : MonoBehaviour {

    [SerializeField]
    private GameObject target;

    [SerializeField]
    private Vector3 offset;

    private float horizontal;
    private float vertical;

    [SerializeField]
    private float max_y, min_y;

    [SerializeField]
    private float rotationSpeed;
    
    private float rotationVelocity;

    [SerializeField]
    private float movementSpeed;

    private CameraZoom cameraZoom;

    private void Start()
    {
        cameraZoom = GetComponent<CameraZoom>();
        
    }

    private void LateUpdate()
    {
        horizontal = InputManager.Get_MouseX * rotationSpeed;
        vertical -= InputManager.Get_MouseY * rotationSpeed;

        vertical = Mathf.Clamp(vertical, min_y, max_y);

        target.transform.Rotate(0, horizontal, 0); 

        float angleY = Mathf.SmoothDampAngle(this.transform.eulerAngles.y, target.transform.eulerAngles.y, ref rotationVelocity, 0);
        this.transform.rotation = Quaternion.Euler(vertical, angleY, 0);

        Quaternion targetRotation = target.transform.rotation;

        Vector3 newPos = targetRotation * offset;
        newPos += new Vector3(target.transform.position.x, target.transform.position.y, target.transform.position.z);
        
        
        this.transform.position = newPos;
        
    }
}
