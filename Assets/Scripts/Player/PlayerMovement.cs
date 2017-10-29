using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float movementSpeed;

    float currentSpeed;
    float backwardsSpeed;

    private Rigidbody rigid;

    private Vector3 horizontalMovement;
    private Vector3 verticalMovement;

    private Animator animator;

    private bool isMoving;
    private bool isRunning;

    private void Start()
    { 
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();

        currentSpeed = movementSpeed;
        backwardsSpeed = movementSpeed / 2;

    }

    private void Update()
    {
        float horizontal= InputManager.Get_MovementInput.x;
        float vertical = InputManager.Get_MovementInput.y;

        Vector3 h_movement = transform.forward * vertical;
        Vector3 v_movement = transform.right * horizontal;

        horizontalMovement = h_movement.normalized;
        verticalMovement = v_movement.normalized;

        isMoving = true;

        if (horizontal != 0 || vertical != 0)
        {
            isMoving = false;
        }

        checkDirectionSpeed(vertical);


        animator.SetBool("isIdle", isMoving);
        animator.SetBool("isRunning", isRunning);
        animator.SetFloat("MovementX", horizontal);
        animator.SetFloat("MovementY", vertical);
    }

    private void checkDirectionSpeed(float dir)
    {

        if (dir < 0)
            movementSpeed = backwardsSpeed;
        else
            movementSpeed = currentSpeed;
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
