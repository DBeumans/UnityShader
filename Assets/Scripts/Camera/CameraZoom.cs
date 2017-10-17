using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour {

    [SerializeField]
    private float max_distance;
    [SerializeField]
    private float min_distance;

    private float distance;
    public float Get_Distance { get { return distance; } }

    private void Start()
    {
        distance = this.gameObject.transform.position.z;
    }

    private void Update()
    {
        calculateZoom();
    }

    private void calculateZoom()
    {
        if (distance > max_distance || distance < min_distance)
            return;
        if (InputManager.Get_ScrollWheel > 0)
            distance++;
        if (InputManager.Get_ScrollWheel < 0)
            distance--;


        

        Vector3 newPos = new Vector3(this.transform.position.x, this.transform.position.y, distance);
        this.transform.position = newPos;


    }
}
