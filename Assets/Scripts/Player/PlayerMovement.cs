using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

    private Rigidbody rigid;

    private Vector3 horizontalMovement;
    private Vector3 verticalMovement;

    [SerializeField]
    private Animator animator;

    private bool isMoving;
    private bool isRunning;

    private void Start()
    { 
        rigid = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        float horizontal= InputManager.Get_MovementInput.x;
        float vertical = InputManager.Get_MovementInput.y;

        Vector3 h_movement = transform.forward * vertical;
        Vector3 v_movement = transform.right * horizontal;

        horizontalMovement = h_movement;
        verticalMovement = v_movement;

        isMoving = false;

        if (horizontal != 0 || vertical != 0)
        {
            isMoving = true;
        }

        if (InputManager.Get_Key_Shift)
        {
            movementSpeed = 10;
            isRunning = true;
        }
        else
        {
            movementSpeed = 5;
            isRunning = false;
        }

        animator.SetBool("isIdle", isMoving);
        animator.SetBool("isRunning", isRunning);
        animator.SetFloat("MovementX", horizontal);
        animator.SetFloat("MovementY", vertical);
    }

    private void FixedUpdate()
    {
        calculateMovement_horizontal();
        calculateMovment_vertical();

    }

    private void calculateMovement_horizontal()
    {
        horizontalMovement = horizontalMovement * movementSpeed * Time.deltaTime;
        rigid.MovePosition(rigid.position + horizontalMovement);
    }

    private void calculateMovment_vertical()
    {
        verticalMovement = verticalMovement * movementSpeed * Time.deltaTime;
        rigid.MovePosition(rigid.position + verticalMovement);
    }
}
