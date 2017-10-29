using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemMovement : MonoBehaviour {

    private float hoverSpeed = 1;
    private float floatingRange = 4;

    private float posY;    

    private void Start()
    {
        posY = this.transform.position.y;
    }

    private void FixedUpdate()
    {
        hover();
    }

    private void hover()
    {
        float floating = posY + hoverSpeed * Mathf.Sin((hoverSpeed *2) * Time.time ) / floatingRange;

        Vector3 pos = new Vector3(this.transform.position.x, floating, this.transform.position.z);
        this.transform.position = pos;
    }

}
